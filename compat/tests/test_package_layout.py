import importlib.util
from pathlib import Path
import tempfile
import unittest
import zipfile

ROOT = Path(__file__).resolve().parents[1]
spec = importlib.util.spec_from_file_location('compat_run', ROOT/'run.py')
assert spec is not None and spec.loader is not None
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)

class PackageLayoutTests(unittest.TestCase):
    def test_real_candidate_layout(self):
        package = ROOT/'diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg'
        self.assertEqual(module.inspect_package(package, True)['version'], '4.0.0-preview.1')

    def test_missing_each_required_assembly_rejected(self):
        package = ROOT/'diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg'
        paths = [f'lib/{t}/Telnyx.net.dll' for t in module.OLD]
        paths += ['lib/net8.0/Telnyx.net.dll', 'lib/net8.0/Telnyx.Sdk.dll']
        for missing in paths:
            with self.subTest(missing=missing), tempfile.TemporaryDirectory() as tmp:
                target=Path(tmp)/'broken.nupkg'
                with zipfile.ZipFile(package) as src, zipfile.ZipFile(target,'w') as dst:
                    for n in src.namelist():
                        if n != missing: dst.writestr(n,src.read(n))
                with self.assertRaises(AssertionError): module.inspect_package(target,True)

    def test_selection_affecting_assets_rejected(self):
        package = ROOT/'diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg'
        with tempfile.TemporaryDirectory() as tmp:
            target=Path(tmp)/'broken.nupkg'
            with zipfile.ZipFile(package) as src, zipfile.ZipFile(target,'w') as dst:
                for n in src.namelist(): dst.writestr(n,src.read(n))
                dst.writestr('ref/net8.0/Telnyx.net.dll', b'negative control')
            with self.assertRaises(AssertionError): module.inspect_package(target,True)

if __name__ == '__main__': unittest.main()
