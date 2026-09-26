#!/usr/bin/env python3
"""Exercise modern SDK regressions using only the packed diagnostic candidate.

No ProjectReference or generated source injection; OS egress denial is mandatory.
Evidence is diagnostic only and never authorizes release/provenance.
"""
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
from xml.sax.saxutils import escape
import zipfile

ROOT = Path(__file__).resolve().parents[1]


def package_identity(path):
    with zipfile.ZipFile(path) as package:
        names = [name for name in package.namelist() if name.lower().endswith('.nuspec')]
        if len(names) != 1:
            raise ValueError('Expected one package manifest')
        doc = ET.fromstring(package.read(names[0]))
    metadata = {node.tag.split('}')[-1]: node.text for node in doc.iter()}
    version = metadata.get('version')
    if metadata.get('id') != 'Telnyx.net' or not isinstance(version, str) or not version:
        raise ValueError('Expected a versioned Telnyx.net candidate')
    return 'Telnyx.net', version


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--candidate', type=Path, required=True)
    parser.add_argument('--probe', choices=['all', 'lifetime', 'url'], default='all')
    args = parser.parse_args()
    candidate = args.candidate.resolve(strict=True)
    package_id, version = package_identity(candidate)
    prefix = shlex.split(os.environ.get('COMPAT_RUNTIME_PREFIX', ''))
    if not prefix:
        raise RuntimeError('COMPAT_RUNTIME_PREFIX must enforce OS egress denial')
    results = ROOT / 'compat/results'
    results.mkdir(exist_ok=True)
    output = Path(tempfile.mkdtemp(prefix='runtime-regressions-', dir=results))
    project = output / 'consumer'
    project.mkdir()
    source = output / 'source'
    source.mkdir()
    shutil.copy2(candidate, source / f'{package_id}.{version}.nupkg')
    dotnet = os.environ.get('DOTNET') or shutil.which('dotnet') or 'dotnet'
    env = {key: value for key, value in os.environ.items()
           if not any(word in key.upper() for word in ('TOKEN', 'SECRET', 'API_KEY', 'PASSWORD'))}
    env.update(NUGET_PACKAGES=str(output / 'packages'), DOTNET_SYSTEM_NET_DISABLEIPV6='1', TelnyxApiKey='dummy')
    classes = ['LifetimeProbe', 'UrlProbe'] if args.probe == 'all' else [{'lifetime': 'LifetimeProbe', 'url': 'UrlProbe'}[args.probe]]
    for name in classes:
        shutil.copy2(ROOT / 'compat/fixtures/regressions' / (name + '.cs'), project / (name + '.cs'))
    (project / 'Program.cs').write_text('\n'.join('await ' + name + '.Run();' for name in classes))
    (project / 'Consumer.csproj').write_text(
        '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework>'
        '<OutputType>Exe</OutputType><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable>'
        '<WarningsAsErrors>NU1605;NU1608;NU1701</WarningsAsErrors></PropertyGroup><ItemGroup>'
        f'<PackageReference Include="Telnyx.net" Version="[{escape(version)}]" />'
        '</ItemGroup></Project>')
    evidence = {'candidate_sha256': hashlib.sha256(candidate.read_bytes()).hexdigest(), 'version': version,
                'probe': args.probe, 'commands': [], 'release_authorized': False}

    def run(name, command):
        process = subprocess.run(list(map(str, command)), cwd=ROOT, env=env, text=True,
                                 stdout=subprocess.PIPE, stderr=subprocess.STDOUT, timeout=180)
        (output / (name + '.log')).write_text(process.stdout)
        evidence['commands'].append({'name': name, 'exit': process.returncode})
        (output / 'evidence.json').write_text(json.dumps(evidence, indent=2))
        print(process.stdout, end='', flush=True)
        if process.returncode:
            raise RuntimeError(f'{name} failed ({process.returncode}); evidence: {output}')

    run('restore', [dotnet, 'restore', project / 'Consumer.csproj', '--source', source,
                    '--source', 'https://api.nuget.org/v3/index.json'])
    installed = output / 'packages' / package_id.lower() / version.lower() / f'{package_id.lower()}.{version.lower()}.nupkg'
    if hashlib.sha256(installed.read_bytes()).hexdigest() != evidence['candidate_sha256']:
        raise RuntimeError('Restored package differs from candidate')
    assets = json.loads((project / 'obj/project.assets.json').read_text())
    selected = assets['targets']['net8.0'][f'{package_id}/{version}']['runtime']
    if 'lib/net8.0/Telnyx.Sdk.dll' not in selected:
        raise RuntimeError(f'Unexpected runtime selection: {selected}')
    evidence['runtime_assets'] = sorted(selected)
    run('build', [dotnet, 'build', project / 'Consumer.csproj', '-c', 'Release', '--no-restore'])
    run('runtime', [*prefix, dotnet, project / 'bin/Release/net8.0/Consumer.dll'])
    print(f'Runtime regressions passed; evidence: {output}')


if __name__ == '__main__':
    main()
