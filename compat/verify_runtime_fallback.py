#!/usr/bin/env python3
"""Run net10 mixed consumers against one exact diagnostic package; never release approval."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import shlex
import shutil
import subprocess
import tempfile
import xml.etree.ElementTree as ET
import zipfile

ROOT = Path(__file__).resolve().parents[1]


def sha256(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--candidate', required=True, type=Path)
    parser.add_argument('--dotnet', default=os.environ.get('DOTNET10') or shutil.which('dotnet'))
    args = parser.parse_args()
    prefix = shlex.split(os.environ.get('COMPAT_RUNTIME_PREFIX', ''))
    if not prefix:
        parser.error('COMPAT_RUNTIME_PREFIX must provide OS egress denial')
    if not args.dotnet:
        parser.error('Supply --dotnet or DOTNET10')
    dotnet = Path(shutil.which(args.dotnet) or args.dotnet).resolve(strict=True)
    candidate = args.candidate.resolve(strict=True)
    digest = sha256(candidate)
    with zipfile.ZipFile(candidate) as archive:
        specs = [n for n in archive.namelist() if n.endswith('.nuspec') and '/' not in n]
        if len(specs) != 1:
            raise ValueError('Expected one root nuspec')
        metadata = ET.fromstring(archive.read(specs[0]))
        ids = metadata.findall('./{*}metadata/{*}id')
        versions = metadata.findall('./{*}metadata/{*}version')
        if len(ids) != 1 or ids[0].text != 'Telnyx.net' or len(versions) != 1 or versions[0].text != '4.0.0-preview.1':
            raise ValueError('Expected Telnyx.net diagnostic preview identity')
    results = ROOT / 'compat/results'
    results.mkdir(exist_ok=True)
    out = Path(tempfile.mkdtemp(prefix='runtime-fallback-', dir=results))
    print(out, flush=True)
    env = {k: v for k, v in os.environ.items()
           if not any(s in k.upper() for s in ('TOKEN', 'SECRET', 'API_KEY', 'APIKEY', 'PASSWORD'))}
    env.update(DOTNET_ROOT=str(dotnet.parent), NUGET_PACKAGES=str(out / 'packages'),
               TelnyxApiKey='dummy-global', DOTNET_CLI_TELEMETRY_OPTOUT='1')
    (out / 'global.json').write_text(json.dumps({'sdk': {'version': '10.0.401', 'rollForward': 'disable'}}))
    feed = out / 'feed'
    feed.mkdir()
    shutil.copyfile(candidate, feed / 'Telnyx.net.4.0.0-preview.1.nupkg')
    rows = []
    summary = {'candidateSha256': digest, 'consumerFramework': 'net10.0',
               'releaseAccepted': False, 'result': 'FAIL', 'commands': rows}

    def run(label, arguments, runtime=False):
        command = [*prefix, *arguments] if runtime else arguments
        command = list(map(str, command))
        process = subprocess.run(command, cwd=out, env=env, text=True,
                                 stdout=subprocess.PIPE, stderr=subprocess.STDOUT, timeout=300)
        (out / (label + '.log')).write_text(process.stdout)
        rows.append({'name': label, 'exit': process.returncode, 'command': command})
        (out / 'commands.json').write_text(json.dumps(rows, indent=2))
        print(label, process.returncode, flush=True)
        if process.returncode:
            raise RuntimeError(f'{label} failed; see {out / (label + ".log")}')
        return process.stdout

    try:
        sdk = run('sdk-version', [dotnet, '--version']).strip()
        if sdk != '10.0.401':
            raise RuntimeError('Expected patched SDK 10.0.401')
        summary['sdk'] = sdk
        for kind, version in [('baseline', '3.1.0'), ('candidate', '4.0.0-preview.1')]:
            directory = out / kind
            directory.mkdir()
            fixture = ROOT / 'compat/fixtures/mixed'
            names = ['LegacyContract.cs', 'LegacyRuntime.cs'] if kind == 'baseline' else [p.name for p in fixture.glob('*.cs')]
            for name in names:
                shutil.copyfile(fixture / name, directory / name)
            if kind == 'baseline':
                (directory / 'Program.cs').write_text('LegacyFixture.Program.Main();')
            project = directory / 'Consumer.csproj'
            project.write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net10.0</TargetFramework><OutputType>Exe</OutputType><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><WarningsAsErrors>NU1605;NU1608;NU1701</WarningsAsErrors></PropertyGroup><ItemGroup><PackageReference Include="Telnyx.net" Version="[' + version + ']" /></ItemGroup></Project>')
            run(kind + '-restore', [dotnet, 'restore', project, '--source', feed, '--source', 'https://api.nuget.org/v3/index.json', '--no-cache'])
            assets = json.loads((directory / 'obj/project.assets.json').read_text())
            selected = assets['targets']['net10.0']['Telnyx.net/' + version]
            expected = ['lib/netstandard2.1/Telnyx.net.dll'] if kind == 'baseline' else ['lib/net8.0/Telnyx.net.dll', 'lib/net8.0/Telnyx.Sdk.dll']
            for asset_kind in ('compile', 'runtime'):
                if not all(name in selected[asset_kind] for name in expected):
                    raise RuntimeError(f'Wrong {asset_kind} assets: {selected}')
            (directory / 'selected-assets.json').write_text(json.dumps(selected, indent=2))
            if kind == 'candidate':
                restored = out / 'packages/telnyx.net' / version / f'telnyx.net.{version}.nupkg'
                if sha256(restored) != digest:
                    raise RuntimeError('Restored package is not the exact candidate')
            run(kind + '-build', [dotnet, 'build', project, '-c', 'Release', '--no-restore'])
            orders = ['legacy-only'] if kind == 'baseline' else ['legacy-first', 'modern-first']
            for order in orders:
                run(kind + '-' + order, [dotnet, directory / 'bin/Release/net10.0/Consumer.dll', order], runtime=True)
        if sha256(candidate) != digest:
            raise RuntimeError('Candidate mutated')
        summary['result'] = 'PASS'
    finally:
        (out / 'results.json').write_text(json.dumps(summary, indent=2))


if __name__ == '__main__':
    main()
