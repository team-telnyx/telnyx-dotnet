"""Execute the production metadata reader with real nupkg archives (requires pwsh)."""
import os
from pathlib import Path
import shutil
import subprocess
import tempfile
import unittest
import zipfile

SCRIPT = Path(__file__).resolve().parents[1] / 'windows.ps1'
PWSH = os.environ.get('PWSH') or shutil.which('pwsh')

@unittest.skipUnless(PWSH, 'PowerShell required; hosted Windows runs this regression')
class WindowsMetadata(unittest.TestCase):
    def invoke(self, directory):
        assert PWSH is not None
        command = r'''
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$ast = [System.Management.Automation.Language.Parser]::ParseFile($env:METADATA_SCRIPT, [ref]$null, [ref]$null)
$fn = $ast.Find({param($node) $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -eq 'Get-InstalledPackageEntry'}, $true)
if (-not $fn) { throw 'Production archive metadata reader missing' }
Invoke-Expression $fn.Extent.Text
Get-InstalledPackageEntry $env:PACKAGE_DIRECTORY 'net45'
'''
        return subprocess.run([PWSH, '-NoLogo', '-NoProfile', '-Command', command],
            env={**os.environ, 'METADATA_SCRIPT': str(SCRIPT), 'PACKAGE_DIRECTORY': str(directory)},
            text=True, capture_output=True)

    def test_archive_only_uses_metadata_not_directory_name(self):
        with tempfile.TemporaryDirectory() as tmp:
            with zipfile.ZipFile(Path(tmp) / 'arbitrary.nupkg', 'w') as archive:
                archive.writestr('Example.nuspec', '<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd"><metadata><id>Example.Dotted.Id</id><version>1.2.3-preview.4</version></metadata></package>')
            result = self.invoke(tmp)
            self.assertEqual(result.returncode, 0, result.stderr)
            self.assertIn('id="Example.Dotted.Id" version="1.2.3-preview.4" targetFramework="net45"', result.stdout)

    def test_invalid_metadata_fails_closed(self):
        valid = '<package><metadata><id>X</id><version>1.0.0</version></metadata></package>'
        cases = {
            'missing-archive': [],
            'missing-nuspec': [('one.nupkg', {'readme.txt': 'no metadata'})],
            'multiple-nuspec': [('one.nupkg', {'one.nuspec': valid, 'two.nuspec': valid})],
            'multiple-archives': [('one.nupkg', {'one.nuspec': valid}), ('two.nupkg', {'two.nuspec': valid})],
            'missing-id': [('one.nupkg', {'one.nuspec': '<package><metadata><version>1</version></metadata></package>'})],
            'multiple-id': [('one.nupkg', {'one.nuspec': valid.replace('<id>X</id>', '<id>X</id><id>Y</id>')})],
            'invalid-xml': [('one.nupkg', {'one.nuspec': '<package>'})],
        }
        for name, archives in cases.items():
            with self.subTest(name=name), tempfile.TemporaryDirectory() as tmp:
                for filename, entries in archives:
                    with zipfile.ZipFile(Path(tmp) / filename, 'w') as archive:
                        for member, text in entries.items():
                            archive.writestr(member, text)
                result = self.invoke(tmp)
                self.assertNotEqual(result.returncode, 0, result.stdout)
                self.assertNotIn('<package id=', result.stdout)

if __name__ == '__main__':
    unittest.main()
