import importlib.util
from pathlib import Path
import tempfile
import unittest
import zipfile

PATH = Path(__file__).resolve().parents[1] / 'verify_runtime_regressions.py'

class RuntimeRunnerTests(unittest.TestCase):
    def test_only_single_telnyx_candidate_is_accepted(self):
        spec = importlib.util.spec_from_file_location('runtime_runner', PATH)
        assert spec is not None and spec.loader is not None
        module = importlib.util.module_from_spec(spec)
        spec.loader.exec_module(module)
        with tempfile.TemporaryDirectory() as d:
            package = Path(d) / 'candidate.nupkg'
            with zipfile.ZipFile(package, 'w') as z:
                z.writestr('Telnyx.net.nuspec', '<package><metadata><id>Telnyx.net</id><version>4.0.0-preview.1</version></metadata></package>')
            self.assertEqual(module.package_identity(package), ('Telnyx.net', '4.0.0-preview.1'))
            with zipfile.ZipFile(package, 'w') as z:
                z.writestr('other.nuspec', '<package><metadata><id>Other</id><version>4.0.0</version></metadata></package>')
            with self.assertRaises(ValueError): module.package_identity(package)

if __name__ == '__main__': unittest.main()
