"""Guard immutable legacy mock inputs; runtime coverage lives in the legacy suite."""
from pathlib import Path
import unittest
import os
import subprocess
import tempfile

ROOT = Path(__file__).resolve().parents[2]

class LegacyMockInputTests(unittest.TestCase):
    def test_inputs_are_frozen_to_the_reproduced_contract(self):
        workflow = (ROOT / '.github/workflows/dotnet.yml').read_text()
        self.assertIn('d9d9dc2ceebe6a6a5302430d76706cfc2b741f70/openapi/spec3.json', workflow)
        self.assertIn('4e19686e312db8ffbb28f7b36912bbaef95aae50c816ad09bb9f4e5238110c1c', workflow)
        self.assertIn('b6aedc5feec717a636b69c4055046185ce11d486', workflow)
        bootstrap = (ROOT / '.github/scripts/before_install.sh').read_text()
        self.assertIn('npm ci', bootstrap)
        self.assertIn('TELNYX_MOCK_PROXY_REVISION', bootstrap)
        self.assertIn('TELNYX_MOCK_SPEC_SHA256', bootstrap)
        self.assertNotIn('> /dev/null &', bootstrap)

    def test_bad_digest_stops_before_dependency_install(self):
        with tempfile.TemporaryDirectory() as tmp:
            fake_curl = Path(tmp) / 'curl'
            fake_curl.write_text('#!/bin/sh\nfor last do :; done\nprintf "{}" > "$last"\n')
            fake_curl.chmod(0o755)
            fake_npm = Path(tmp) / 'npm'
            marker = Path(tmp) / 'unexpected-install'
            fake_npm.write_text('#!/bin/sh\ntouch "$INSTALL_MARKER"\nexit 99\n')
            fake_npm.chmod(0o755)
            env = dict(os.environ, PATH=tmp + os.pathsep + os.environ['PATH'],
                       TELNYX_MOCK_OPEN_API_URI='https://example.invalid/spec.json',
                       TELNYX_MOCK_SPEC_SHA256='0' * 64,
                       TELNYX_MOCK_PROXY_REVISION='0' * 40,
                       INSTALL_MARKER=str(marker), RUNNER_TEMP=tmp, TMPDIR=tmp)
            result = subprocess.run(['bash', '.github/scripts/before_install.sh'],
                                    cwd=ROOT, env=env, text=True, capture_output=True)
            self.assertNotEqual(result.returncode, 0)
            self.assertIn('Mock spec digest mismatch', result.stderr)
            self.assertFalse(marker.exists())

if __name__ == '__main__':
    unittest.main()
