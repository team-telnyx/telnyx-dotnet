"""TEST-ONLY receipts; none is authentic producer evidence."""
import importlib.util
import json
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest

ROOT = Path(__file__).resolve().parents[2]

class ProductionGateTests(unittest.TestCase):
    def test_all_untrusted_evidence_is_rejected_by_both_entrypoints(self):
        cases = ['missing', 'unsigned', 'wrong-producer', 'wrong-workflow',
                 'stale-head', 'altered-artifact', 'inaccessible', 'failure',
                 'cancelled', 'skipped', 'changed-pin', 'changed-legacy',
                 'changed-custom', 'build-source-substitution', 'staged-dll-substitution']
        for case in cases:
            for entrypoint in ['pack.py', 'verify-generated.py']:
                with self.subTest(case=case, entrypoint=entrypoint), tempfile.TemporaryDirectory() as tmp:
                    d = Path(tmp)
                    (d/'manifest.json').write_text(json.dumps({'test_only': True, 'case': case, 'success': True}))
                    if case != 'missing':
                        (d/'receipt.json').write_text(json.dumps({'test_only': True, 'conclusion': case}))
                    p = subprocess.run([sys.executable, str(ROOT/'eng'/entrypoint), '--repository-root', tmp,
                                        '--expected-head', 'a'*40, '--manifest', str(d/'manifest.json'),
                                        '--evidence-dir', tmp], capture_output=True, text=True)
                    self.assertEqual(p.returncode, 1)
                    self.assertIn('trusted producer verification is not provisioned', p.stderr)
                    self.assertEqual(list(d.rglob('*.nupkg')), [])

    def test_unsigned_manifest_cannot_enable_pack(self):
        with tempfile.TemporaryDirectory() as tmp:
            d = Path(tmp)
            (d/'manifest.json').write_text(json.dumps({'success': True, 'test_only': True}))
            p = subprocess.run([sys.executable, str(ROOT/'eng/pack.py'), '--repository-root', str(d), '--expected-head', 'a'*40, '--manifest', str(d/'manifest.json'), '--evidence-dir', str(d), '--report', str(d/'report.json')], capture_output=True, text=True)
            self.assertNotEqual(p.returncode, 0)
            self.assertIn('trusted producer verification is not provisioned', p.stderr)
            self.assertEqual(list(d.rglob('*.nupkg')), [])

class InventoryTests(unittest.TestCase):
    def test_git_and_worktree_bytes_and_extra_inputs_are_bound(self):
        import runpy
        gate = runpy.run_path(str(ROOT/'eng/verify-generated.py'))
        self.assertTrue(callable(gate.get('tree_inventory')), 'missing tree_inventory')
        with tempfile.TemporaryDirectory() as tmp:
            root = Path(tmp)
            def git(*args):
                return subprocess.check_output(['git', '-C', tmp, *args], stderr=subprocess.DEVNULL).decode().strip()
            git('init')
            (root/'generated').mkdir()
            source = root/'generated/a.cs'
            source.write_bytes(b'TEST-ONLY\r\n')
            git('add', '.')
            git('-c', 'user.name=TEST-ONLY', '-c', 'user.email=test@example.invalid', 'commit', '-m', 'test-only')
            head = git('rev-parse', 'HEAD')
            inventory = gate['tree_inventory'](root, head, ['generated'])
            self.assertEqual(inventory[0][0], 'generated/a.cs')
            for mutation in ('modified', 'deleted', 'extra', 'symlink'):
                with self.subTest(mutation=mutation):
                    if mutation == 'modified': source.write_bytes(b'TEST-ONLY\n')
                    elif mutation == 'deleted': source.unlink()
                    elif mutation == 'extra': (root/'generated/new.props').write_text('TEST-ONLY')
                    else:
                        source.unlink()
                        source.symlink_to('/tmp')
                    with self.assertRaises(gate['Rejected']):
                        gate['tree_inventory'](root, head, ['generated'])
                    if source.is_symlink(): source.unlink()
                    source.write_bytes(b'TEST-ONLY\r\n')
                    (root/'generated/new.props').unlink(missing_ok=True)
            with self.assertRaises(gate['Rejected']):
                gate['tree_inventory'](root, '0'*40, ['generated'])

class ContractTests(unittest.TestCase):
    def test_test_only_contract_rejects_each_changed_binding(self):
        import runpy
        gate = runpy.run_path(str(ROOT/'eng/verify-generated.py'))
        self.assertIn('check_bindings', gate)
        expected = {'sdk_repository': 'TEST-ONLY/sdk', 'head': 'a'*40,
                    'pins': {'csharp': 'b'*40, 'core': 'c'*40, 'config': 'd'*40,
                             'lock_sha256': '1'*64, 'worker_sha256': '2'*64,
                             'schema_sha256': '3'*64, 'config_sha256': '4'*64,
                             'toolchain': 'TEST-ONLY'},
                    'ownership_sha256': '5'*64, 'generated_sha256': '6'*64,
                    'legacy_sha256': '7'*64, 'custom_sha256': '8'*64,
                    'pack_input_sha256': '9'*64}
        receipt = dict(expected, reproduction_one='6'*64, reproduction_two='6'*64,
                       conclusion='success', jobs={'regenerate': 'success', 'build': 'success', 'typed-probes': 'success'})
        gate['check_bindings'](expected, receipt)
        for key in expected:
            with self.subTest(binding=key):
                changed = dict(receipt, **{key: 'TEST-ONLY-TAMPER'})
                with self.assertRaises(gate['Rejected']):
                    gate['check_bindings'](expected, changed)
        for change in ({'jobs': {}}, {'jobs': {'regenerate': 'skipped'}},
                       {'reproduction_one': 'TEST-ONLY-MISMATCH'},
                       {'reproduction_two': 'TEST-ONLY-MISMATCH'}):
            with self.subTest(change=change), self.assertRaises(gate['Rejected']):
                gate['check_bindings'](expected, dict(receipt, **change))
        for status in ['failure', 'cancelled', 'skipped', None]:
            with self.subTest(status=status), self.assertRaises(gate['Rejected']):
                gate['check_bindings'](expected, dict(receipt, conclusion=status))

if __name__ == '__main__':
    unittest.main()
