#!/usr/bin/env python3
"""Fail-closed release gate. No local manifest can provision trust.

Production authentication is deliberately sealed until a protected, reviewed CI
producer/relay adapter exists. Contract helpers are exercised with TEST-ONLY
fixtures; they do not authenticate a receipt or authorize packaging.
"""
import argparse
import hashlib
import json
from pathlib import Path
import sys
import re
import subprocess


def tree_inventory(root, head, owned_roots):
    """Compare raw committed/working bytes under PROTECTED ownership roots.

    Caller must authenticate the ownership map and classify ALL build inputs.
    This utility cannot determine whether the caller's scope is trustworthy.
    """
    root = Path(root).resolve()
    if not re.fullmatch(r'[0-9a-f]{40}', head):
        raise Rejected('full immutable head required')
    def git(*args):
        try:
            return subprocess.check_output(['git', '-C', str(root), *args], stderr=subprocess.DEVNULL)
        except subprocess.CalledProcessError as error:
            raise Rejected('git identity unavailable') from error
    if git('rev-parse', 'HEAD').decode().strip() != head:
        raise Rejected('stale head')
    if not owned_roots or any(not p or p.startswith('/') or '..' in p.split('/') or '\\' in p for p in owned_roots):
        raise Rejected('unsafe ownership roots')
    entries = []
    seen = set()
    for row in git('ls-tree', '-rz', head).split(b'\0'):
        if not row:
            continue
        meta, raw_path = row.split(b'\t', 1)
        path = raw_path.decode('utf-8')
        if not any(path == p or path.startswith(p.rstrip('/')+'/') for p in owned_roots):
            continue
        mode, kind, oid = meta.decode().split()
        if mode not in ('100644', '100755') or kind != 'blob' or path.casefold() in seen:
            raise Rejected('unsafe mode or case collision')
        seen.add(path.casefold())
        file = root/path
        if any(p.is_symlink() for p in [file, *file.parents] if p != root.parent):
            raise Rejected('symlink input')
        if not file.is_file():
            raise Rejected('deleted input')
        data = git('cat-file', 'blob', oid)
        if file.read_bytes() != data:
            raise Rejected('working tree differs from committed bytes')
        if bool(file.stat().st_mode & 0o111) != (mode == '100755'):
            raise Rejected('working mode differs')
        entries.append([path, mode, len(data), hashlib.sha256(data).hexdigest()])
    actual = set()
    for owned in owned_roots:
        base = root/owned
        for file in ([base] if base.is_file() else base.rglob('*')):
            if file.is_symlink():
                raise Rejected('symlink input')
            if file.is_file():
                actual.add(file.relative_to(root).as_posix())
    if not entries or actual != {e[0] for e in entries}:
        raise Rejected('extra, missing, or untracked input')
    return sorted(entries, key=lambda e: e[0].encode('utf-8'))


def tree_digest(inventory):
    return hashlib.sha256(json.dumps(inventory, ensure_ascii=False, separators=(',', ':')).encode('utf-8')).hexdigest()

class Rejected(ValueError):
    pass

def check_bindings(expected, receipt):
    """Content contract ONLY, called after future external authentication.

    Passing this helper is not proof: arbitrary callers can construct receipts.
    Production main intentionally cannot reach it until trust is provisioned.
    """
    required = ('sdk_repository', 'head', 'pins', 'ownership_sha256',
                'generated_sha256', 'legacy_sha256', 'custom_sha256',
                'pack_input_sha256')
    for key in required:
        if not expected.get(key) or receipt.get(key) != expected[key]:
            raise Rejected('binding mismatch: '+key)
    for key in ('csharp', 'core', 'config', 'lock_sha256', 'worker_sha256',
                'schema_sha256', 'config_sha256', 'toolchain'):
        if not expected['pins'].get(key):
            raise Rejected('missing source pin: '+key)
    if receipt.get('conclusion') != 'success':
        raise Rejected('producer did not succeed')
    if receipt.get('jobs') != dict.fromkeys(('regenerate', 'build', 'typed-probes'), 'success'):
        raise Rejected('missing or unsuccessful prerequisite')
    if any(receipt.get(k) != expected['generated_sha256']
           for k in ('reproduction_one', 'reproduction_two')):
        raise Rejected('reproduction differs from committed generated tree')

def authenticate_producer(evidence_dir):
    # Do not read identities, executable commands, or keys from candidate input.
    raise Rejected('trusted producer verification is not provisioned')

def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--repository-root', default='.')
    parser.add_argument('--expected-head', required=True)
    parser.add_argument('--manifest', default='eng/generation-manifest.json')
    parser.add_argument('--evidence-dir', required=True)
    parser.add_argument('--report')
    parser.add_argument('--version')
    args = parser.parse_args(argv)
    try:
        authenticate_producer(Path(args.evidence_dir))
        # No success branch: authentication alone cannot authorize a build.
        raise Rejected('isolated verified build and pack attestation not provisioned')
    except Rejected as error:
        report = {'release_accepted': False, 'expected_head': args.expected_head,
                  'reason': str(error)}
        if args.report:
            target = Path(args.report)
            target.parent.mkdir(parents=True, exist_ok=True)
            target.write_text(json.dumps(report, indent=2)+'\n')
        print('BLOCKED: '+str(error), file=sys.stderr)
        return 1

if __name__ == '__main__':
    sys.exit(main())
