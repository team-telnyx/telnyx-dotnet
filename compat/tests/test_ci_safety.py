"""Release quarantine is deliberate until authenticated provenance is provisioned."""
from pathlib import Path
import unittest

ROOT = Path(__file__).resolve().parents[2]

class CiSafety(unittest.TestCase):
    def test_no_release_event_or_publication_authority(self):
        workflow = (ROOT / '.github/workflows/publish-nuget.yml').read_text()
        for forbidden in ('release:', 'nuget push', 'NuGet/login', 'id-token: write', 'dotnet pack', 'secrets.'):
            self.assertNotIn(forbidden, workflow)
        self.assertIn('exit 1', workflow)
        self.assertIn('workflow_dispatch:', workflow)

if __name__ == '__main__':
    unittest.main()
