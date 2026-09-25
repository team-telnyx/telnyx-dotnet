#!/usr/bin/env python3
"""Local diagnostic refresh; never grants release/provenance approval."""
import json, os, shutil, subprocess, shlex, tempfile, sys
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
(ROOT/'compat/results').mkdir(exist_ok=True)
OUT=Path(tempfile.mkdtemp(prefix='mixed-exact8-', dir=ROOT/'compat/results'))
DOTNET=os.environ.get('DOTNET') or shutil.which('dotnet') or 'dotnet'
env={k:v for k,v in os.environ.items() if not any(s in k.upper() for s in ['TOKEN','SECRET','API_KEY','PASSWORD'])}
env.update(NUGET_PACKAGES=str(OUT/'packages'),DOTNET_SYSTEM_NET_DISABLEIPV6='1',TelnyxApiKey='dummy-global')
rows=[]
def run(name,args,guard=False):
    if guard:
        prefix=shlex.split(os.environ.get('COMPAT_RUNTIME_PREFIX', ''))
        if not prefix: raise RuntimeError('COMPAT_RUNTIME_PREFIX must provide OS egress denial')
        args=[*prefix,*args]
    p=subprocess.run(list(map(str,args)),cwd=ROOT,env=env,stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True,timeout=150)
    (OUT/(name+'.log')).write_text(p.stdout)
    rows.append({'name':name,'exit':p.returncode,'command':list(map(str,args))})
    (OUT/'commands.json').write_text(json.dumps(rows,indent=2))
    print(name,p.returncode,flush=True)
    return p.returncode
run('unit',[sys.executable,'-m','unittest','discover','-s','compat/tests','-v'])
run('dependency-matrix',[sys.executable,'compat/dependencies.py','--candidate','compat/diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg'])
for kind,version in [('baseline','3.1.0'),('candidate','4.0.0-preview.1')]:
    d=OUT/kind;d.mkdir(exist_ok=True)
    pins={'Telnyx.net':version,'System.Text.Json':'8.0.0','System.Text.Encodings.Web':'8.0.0','System.IO.Pipelines':'8.0.0'}
    (d/'Consumer.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework><OutputType>Exe</OutputType><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><WarningsAsErrors>NU1605;NU1608;NU1701</WarningsAsErrors></PropertyGroup><ItemGroup>'+''.join(f'<PackageReference Include="{k}" Version="[{v}]" />' for k,v in pins.items())+'</ItemGroup></Project>')
    fixture=ROOT/'compat/fixtures/mixed'
    if kind=='candidate':
        for f in fixture.glob('*.cs'): shutil.copy2(f,d/f.name)
    else:
        for name in ['LegacyContract.cs','LegacyRuntime.cs']:shutil.copy2(fixture/name,d/name)
        (d/'Program.cs').write_text('LegacyFixture.Program.Main();')
    if run(kind+'-restore',[DOTNET,'restore',d/'Consumer.csproj','--source',ROOT/'compat/diagnostic-artifacts','--source','https://api.nuget.org/v3/index.json'])==0:
        assets=json.loads((d/'obj/project.assets.json').read_text())
        target=assets['targets']['net8.0']
        assert all(k+'/'+v in target for k,v in pins.items())
        (d/'verified-pins.json').write_text(json.dumps(pins,indent=2))
        if run(kind+'-build',[DOTNET,'build',d/'Consumer.csproj','-c','Release','--no-restore'])==0:
            for order in ['legacy-first','modern-first']:
                run(kind+'-'+order,[DOTNET,d/'bin/Release/net8.0/Consumer.dll',order],True)
if run('safe-test-build',[DOTNET,'build','src/TelnyxTests/TelnyxTests.csproj','-c','Release'])==0:
    run('safe-uri-tests',[DOTNET,'test','src/TelnyxTests/TelnyxTests.csproj','-c','Release','--no-build','--no-restore','--filter','FullyQualifiedName~UriParserTests','--logger','trx;LogFileName=stj8-safe.trx','--results-directory',OUT/'safe-tests'],True)
run('modern-netstandard',[DOTNET,'build','modern/src/Telnyx.Sdk/Telnyx.Sdk.csproj','-c','Release','-f','netstandard2.0','--nologo'])
raise SystemExit(any(r['exit'] for r in rows))
