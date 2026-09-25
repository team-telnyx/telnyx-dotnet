#!/usr/bin/env python3
"""Compare real baseline/candidate restores for existing net8 direct pins."""
import argparse
import os
import shutil
import json
from pathlib import Path
import subprocess
import tempfile
from run import DEPS
p=argparse.ArgumentParser();p.add_argument('--candidate',type=Path,required=True);a=p.parse_args()
root=Path(__file__).resolve().parent
out=Path(tempfile.mkdtemp(prefix='dependencies-',dir=root/'results'))
dotnet=os.environ.get('DOTNET') or shutil.which('dotnet') or 'dotnet'
cases={'legacy-minima': DEPS, 'encodings8': {'System.Text.Encodings.Web':'8.0.0'}, 'stj8': {'System.Text.Json':'8.0.0'}, 'pipelines8': {'System.IO.Pipelines':'8.0.0'}, 'encodings9': {'System.Text.Encodings.Web':'9.0.9'}}
rows=[]
for name,pins in cases.items():
 for kind,version in [('baseline','3.1.0'),('candidate','4.0.0-preview.1')]:
  d=out/(name+'-'+kind);d.mkdir()
  refs={'Telnyx.net':version,**pins}
  project=d/'Consumer.csproj'
  project.write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework><WarningsAsErrors>NU1605;NU1608;NU1701</WarningsAsErrors></PropertyGroup><ItemGroup>'+''.join('<PackageReference Include="'+k+'" Version="['+v+']" />' for k,v in refs.items())+'</ItemGroup></Project>')
  r=subprocess.run([dotnet,'restore',str(project),'--source',str(a.candidate.resolve().parent),'--source','https://api.nuget.org/v3/index.json'],stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True,timeout=120)
  (d/'restore.log').write_text(r.stdout)
  rows.append({'case':name,'kind':kind,'exit':r.returncode,'log':str(d/'restore.log')})
  (out/'results.json').write_text(json.dumps(rows,indent=2))
print(json.dumps({'results':str(out/'results.json'),'rows':rows},indent=2))
raise SystemExit(1 if any(r['exit'] for r in rows) else 0)
