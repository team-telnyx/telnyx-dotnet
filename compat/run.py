#!/usr/bin/env python3
"""Real NuGet package consumers. Baseline characterization, not release certification.
No ProjectReference, synthetic modern assembly, or product network access.
"""
import argparse
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import tempfile
import urllib.request
import xml.etree.ElementTree as ET
import zipfile

ROOT = Path(__file__).resolve().parent
BASE_SHA = '4f409eda478a7afe92aea6de211e061eab20bfc5143a3d69202996e9e573de03'
TFMS = ['net45', 'net452', 'net461', 'net462', 'net472', 'net48', 'netstandard2.0', 'netstandard2.1', 'net8.0']
OLD = ['net45', 'net452', 'netstandard2.0', 'netstandard2.1']
DEPS = {'Microsoft.CSharp': '4.7.0', 'Newtonsoft.Json': '13.0.3', 'Rebex.Elliptic.Ed25519': '1.2.1', 'System.Collections.Immutable': '1.7.0'}

def digest(path):
    return hashlib.sha256(Path(path).read_bytes()).hexdigest()

def inspect_package(path, candidate=False, modern_tfm='net8.0'):
    with zipfile.ZipFile(path) as z:
        names = z.namelist()
        root = ET.fromstring(z.read(next(n for n in names if n.endswith('.nuspec'))))
        ns = {'n': root.tag.split('}')[0][1:]}
        meta = root.find('n:metadata', ns)
        assert meta is not None, 'missing package metadata'
        package_id = meta.find('n:id', ns)
        package_version = meta.find('n:version', ns)
        assert package_id is not None and package_id.text == 'Telnyx.net', 'wrong package ID'
        assert package_version is not None and package_version.text, 'missing version'
        version = package_version.text
        groups = {}
        for group in meta.findall('n:dependencies/n:group', ns):
            groups[group.attrib['targetFramework']] = {d.attrib['id']: d.attrib['version'] for d in group}
        for tfm in OLD:
            assert f'lib/{tfm}/Telnyx.net.dll' in names, f'missing legacy DLL: {tfm}'
        assert not any(n.startswith(('ref/', 'runtimes/', 'build/', 'buildTransitive/')) for n in names), 'unexpected selection-affecting assets'
        keys = { 'net45': '.NETFramework4.5', 'net452': '.NETFramework4.5.2', 'netstandard2.0': '.NETStandard2.0', 'netstandard2.1': '.NETStandard2.1' }
        for tfm, key in keys.items():
            assert groups[key] == DEPS, f'legacy dependency group changed: {tfm}: {groups[key]}'
            assert f'lib/{tfm}/Telnyx.Sdk.dll' not in names, 'modern must not leak into legacy groups'
        if candidate:
            for dll in ['Telnyx.net.dll','Telnyx.Sdk.dll']:
                assert f'lib/{modern_tfm}/{dll}' in names, f'incomplete modern group: {dll}'
            assert not any('Telnyx' in dep for g in groups.values() for dep in g), 'second Telnyx package dependency'
        return {'version': version, 'sha256': digest(path), 'files': names, 'dependency_groups': groups}

def main():
    parser=argparse.ArgumentParser()
    parser.add_argument('--dotnet', default=os.environ.get('DOTNET') or shutil.which('dotnet') or 'dotnet')
    parser.add_argument('--candidate', type=Path)
    parser.add_argument('--modern-tfm', default='net8.0', choices=['net8.0','net10.0'])
    args=parser.parse_args()
    out=ROOT/'results'; out.mkdir(exist_ok=True)
    run=Path(tempfile.mkdtemp(prefix='run-', dir=out))
    env={k:v for k,v in os.environ.items() if not any(x in k.upper() for x in ['TOKEN','SECRET','API_KEY','APIKEY','PASSWORD'])}
    env.update(DOTNET_ROOT=str(Path(args.dotnet).parent), DOTNET_CLI_HOME=str(run/'home'), NUGET_PACKAGES=str(run/'packages'), DOTNET_NOLOGO='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', TelnyxApiKey='dummy-global')
    records=[]
    def command(label, *cmd, cwd=run, expected=0):
        p=subprocess.run(list(map(str,cmd)),cwd=cwd,env=env,stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True,timeout=300)
        (run/(label+'.log')).write_text(p.stdout)
        records.append({'label':label,'command':list(map(str,cmd)), 'cwd':str(cwd),'exit':p.returncode})
        (run/'commands.json').write_text(json.dumps(records,indent=2))
        assert p.returncode==expected, f'{label}: exit {p.returncode}, see {run}/{label}.log'
        return p.stdout
    def runtime_command(label, *cmd):
        # CI may wrap only runtime execution in an OS network namespace.
        # Restore/build remain outside it; no credentials are passed to children.
        import shlex
        prefix = shlex.split(os.environ.get('COMPAT_RUNTIME_PREFIX', ''))
        return command(label, *prefix, *cmd)
    report={'run':str(run), 'scope':'baseline characterization; candidate checks are partial release gates', 'pending':['Windows runtime and packages.config upgrade', 'full API diff', 'modern mixed consumer and new runtime fallback', 'full feature/wire coverage']}
    (out/'latest.txt').write_text(str(run)+'\n')
    command('sdk',args.dotnet,'--info')
    command('nuget-version',args.dotnet,'nuget','--version')
    feed=run/'feed'; feed.mkdir()
    baseline=feed/'telnyx.net.3.1.0.nupkg'
    urllib.request.urlretrieve('https://api.nuget.org/v3-flatcontainer/telnyx.net/3.1.0/telnyx.net.3.1.0.nupkg',baseline)
    assert digest(baseline)==BASE_SHA, 'baseline hash mismatch'
    report['baseline']=inspect_package(baseline)
    # Negative control: remove a required DLL from a real package; verifier must reject it.
    broken=run/'missing-legacy.nupkg'
    with zipfile.ZipFile(baseline) as src, zipfile.ZipFile(broken,'w') as dst:
        for n in src.namelist():
            if n != 'lib/net452/Telnyx.net.dll': dst.writestr(n,src.read(n))
    try: inspect_package(broken)
    except AssertionError as e:
        assert str(e)=='missing legacy DLL: net452'
        report['negative_missing_dll']='PASS: '+str(e)
    else: raise AssertionError('verifier accepted missing legacy DLL')
    packages=[('baseline',baseline)]
    if args.candidate:
        candidate=feed/args.candidate.name; shutil.copy2(args.candidate,candidate)
        report['candidate']=inspect_package(candidate,True,args.modern_tfm)
        assert report['candidate']['version']!='3.1.0'
        packages.append(('candidate',candidate))
    extracted=run/'extracted'; extracted.mkdir()
    with zipfile.ZipFile(baseline) as z:
        for tfm in OLD:
            p=extracted/tfm; p.mkdir(); (p/'Telnyx.net.dll').write_bytes(z.read(f'lib/{tfm}/Telnyx.net.dll'))
    inspector=run/'inspect'; inspector.mkdir()
    shutil.copy2(ROOT/'inspect/Program.cs',inspector/'Program.cs')
    (inspector/'inspect.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework><OutputType>Exe</OutputType><ImplicitUsings>enable</ImplicitUsings></PropertyGroup></Project>')
    command('inspect-build',args.dotnet,'build',inspector/'inspect.csproj','-c','Release','--nologo')
    metadata=json.loads(command('identity',args.dotnet,inspector/'bin/Release/net8.0/inspect.dll',*[extracted/t/'Telnyx.net.dll' for t in OLD]))
    for row in metadata:
        assert row['identity']=='Telnyx.net, Version=3.1.0.0, Culture=neutral, PublicKeyToken=null'
        assert row['publicKey']=='' and 'StrongNameSigned' not in row['corFlags']
    (run/'identity.json').write_text(json.dumps(metadata,indent=2))
    report['consumers']=[]
    for kind,package in packages:
        version=report[kind]['version']
        for tfm in dict.fromkeys(TFMS + ([args.modern_tfm] if args.candidate else [])):
            p=run/(kind+'-'+tfm); p.mkdir()
            shutil.copy2(ROOT/'LegacyContract.cs',p/'LegacyContract.cs')
            runtime=tfm in ('net8.0', args.modern_tfm)
            if runtime: shutil.copy2(ROOT/'Runtime.cs',p/'Program.cs')
            refs='<PackageReference Include="Telnyx.net" Version="['+version+']" />'
            if tfm.startswith('net4'): refs+='<PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.3" PrivateAssets="All" />'
            project=p/'Consumer.csproj'
            project.write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>'+tfm+'</TargetFramework><OutputType>'+('Exe' if runtime else 'Library')+'</OutputType><LangVersion>latest</LangVersion><WarningsAsErrors>NU1605;NU1608;NU1701</WarningsAsErrors></PropertyGroup><ItemGroup>'+refs+'</ItemGroup><Target Name="CaptureReferences" AfterTargets="ResolveReferences"><WriteLinesToFile File="compiler-references.txt" Lines="@(ReferencePath)" Overwrite="true" /></Target></Project>')
            command(kind+'-'+tfm+'-restore',args.dotnet,'restore',project,'--source',feed,'--source','https://api.nuget.org/v3/index.json','--no-cache')
            command(kind+'-'+tfm+'-build',args.dotnet,'build',project,'-c','Release','--no-restore','--nologo')
            assets=json.loads((p/'obj/project.assets.json').read_text())
            target=next(iter(assets['targets'].values()))
            telnyx=target['Telnyx.net/'+version]
            selected='net45' if tfm=='net45' else 'net452' if tfm.startswith('net4') else 'netstandard2.1' if runtime else tfm
            if kind=='candidate' and tfm==args.modern_tfm: selected=args.modern_tfm
            for section in ['compile','runtime']:
                assert f'lib/{selected}/Telnyx.net.dll' in telnyx[section], (tfm,section,telnyx)
                if kind=='candidate' and tfm==args.modern_tfm: assert f'lib/{selected}/Telnyx.Sdk.dll' in telnyx[section]
            assert 'runtimeTargets' not in telnyx
            assert 'Telnyx.net.dll' in (p/'compiler-references.txt').read_text()
            graph={k:v for k,v in target.items()}
            (p/'resolved-graph.json').write_text(json.dumps(graph,indent=2))
            row={'kind':kind,'tfm':tfm,'selected':selected,'compile':telnyx['compile'],'runtime':telnyx['runtime'],'libraries':sorted(target)}
            if runtime:
                runtime_command(kind+'-'+tfm+'-runtime',args.dotnet,p/('bin/Release/'+tfm+'/Consumer.dll'))
                row['runtime_result']='PASS'
            report['consumers'].append(row)
    # Candidate binary swap: original compiled customer DLL + candidate runtime/deps,
    # preserving and hashing the original before and after; no recompile.
    if args.candidate:
        old=run/('baseline-'+args.modern_tfm+'/bin/Release/'+args.modern_tfm+'/Consumer.dll')
        dest=run/('candidate-'+args.modern_tfm+'/bin/Release/'+args.modern_tfm+'/Consumer.dll')
        original=digest(old); shutil.copy2(old,dest)
        runtime_command('candidate-precompiled',args.dotnet,dest)
        assert digest(dest)==original
        report['precompiled_consumer_sha256']=original
    (run/'results.json').write_text(json.dumps(report,indent=2))
    print(json.dumps({'results':str(run/'results.json'),'consumers':len(report['consumers']),'negative_control':report['negative_missing_dll']},indent=2))

if __name__=='__main__': main()
