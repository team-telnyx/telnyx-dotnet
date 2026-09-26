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

    def test_decoder_patch_rejects_unknown_bytes_without_mutation(self):
        with tempfile.TemporaryDirectory() as tmp:
            decoder = Path(tmp) / 'deepObject.js'
            # Include the real insertion anchor: only the digest guard can
            # reject this plausible-but-unaudited decoder before mutation.
            original = b'function decode() {\n    function construct(currentPath, def) {\n    }\n}\n'
            decoder.write_bytes(original)
            result = subprocess.run(
                ['node', str(ROOT / '.github/mock/patch-deep-object.cjs'), str(decoder)],
                text=True, capture_output=True)
            self.assertNotEqual(result.returncode, 0)
            self.assertIn('Unexpected Prism decoder bytes', result.stderr)
            self.assertEqual(decoder.read_bytes(), original)

    def test_decoder_controls_run_before_mock_start(self):
        bootstrap = (ROOT / '.github/scripts/before_install.sh').read_text()
        patch = bootstrap.index('node .github/mock/patch-deep-object.cjs "$decoder"')
        controls = bootstrap.index('node .github/mock/test-deep-object.cjs "$decoder"')
        launch = bootstrap.index('node "$mock_root/prism/node_modules/@stoplight/prism-cli/dist/index.js" mock')
        self.assertLess(patch, controls)
        self.assertLess(controls, launch)
        self.assertIn('set -euo pipefail', bootstrap)

    def test_historical_contract_is_separate_and_pinned(self):
        bootstrap = (ROOT / '.github/scripts/before_install.sh').read_text()
        self.assertIn('1d97a787b3c88edce00428076ec0c236392a3f18/openapi/spec3.json', bootstrap)
        self.assertIn('02d40213df0e3401e4720b8924fe4f2d56314b630ec9d57a5f13fb3132e05482', bootstrap)
        self.assertIn('--port 4013', bootstrap)
        self.assertIn('historical-prism.log', bootstrap)
        self.assertIn('"$historical_pid"', bootstrap)
        self.assertLess(bootstrap.index('Historical spec digest mismatch'), bootstrap.index('npm ci'))
        scope = (ROOT / 'src/TelnyxTests/HistoricalContractTest.cs').read_text()
        self.assertIn('historical-1d97a787', scope)
        self.assertIn('SetApiBase(this.originalBase)', scope)
        # The default suite must continue using the current-contract server.
        current = (ROOT / 'src/TelnyxTests/TelnyxMockFixture.cs').read_text()
        self.assertNotIn('4013', current)

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
