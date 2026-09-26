import json
from pathlib import Path
import unittest

ROOT = Path(__file__).resolve().parents[2]

class BuildToolchainTests(unittest.TestCase):
    def test_serviced_sdk_is_selected_not_just_installed(self):
        sdk = json.loads((ROOT / 'global.json').read_text())['sdk']
        self.assertEqual(sdk['version'], '8.0.425')
        self.assertEqual(sdk['rollForward'], 'disable')
        self.assertFalse(sdk['allowPrerelease'])

    def test_generated_project_uses_sdk_sourcelink(self):
        project = (ROOT / 'modern/src/Telnyx.Sdk/Telnyx.Sdk.csproj').read_text()
        self.assertNotIn('PackageReference Include="Microsoft.SourceLink.GitHub"', project)

if __name__ == '__main__':
    unittest.main()
