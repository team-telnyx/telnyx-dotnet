"""NuGet.Client release-6.11.x RestoreCommand.cs IsPackagesConfig predicate.
Source: https://github.com/NuGet/NuGet.Client/blob/release-6.11.x/src/NuGet.Clients/NuGet.CommandLine/Commands/RestoreCommand.cs
This source-contract regression is not Windows execution evidence.
"""
from pathlib import Path
import re
import unittest

class WindowsConfig(unittest.TestCase):
    def test_restore_inputs_are_recognized_packages_configs(self):
        script = (Path(__file__).resolve().parents[1] / 'windows.ps1').read_text()
        match = re.search(r'\$Config = Join-Path \$Work "([^"]+)"', script)
        assert match is not None
        name = match.group(1)
        for version in ('3.1.0', '4.0.0-preview.1'):
            resolved = name.replace('$Version', version).lower()
            self.assertTrue(resolved == 'packages.config' or
                            (resolved.startswith('packages.') and resolved.endswith('.config')), resolved)
        self.assertIn("'packages.3.1.0.config'", script)

if __name__ == '__main__':
    unittest.main()
