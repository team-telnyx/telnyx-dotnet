#!/usr/bin/env python3
"""LOCAL experiment only: not the provenance-gated release pack entrypoint.
Build actual generated source and compose a non-publishable compatibility specimen.
"""
import hashlib
import os
import urllib.request
import json
from pathlib import Path
import shutil
import subprocess
import xml.etree.ElementTree as ET
import zipfile
from run import BASE_SHA, inspect_package

ROOT = Path(__file__).resolve().parents[1]
DOTNET = os.environ.get('DOTNET') or shutil.which('dotnet') or 'dotnet'
BASE = ROOT / 'compat/diagnostic-artifacts/telnyx.net.3.1.0.nupkg'
VERSION = '4.0.0-preview.1'
OUT = ROOT / 'compat/diagnostic-artifacts'
OUT.mkdir(exist_ok=True)
if not BASE.exists():
    urllib.request.urlretrieve('https://api.nuget.org/v3-flatcontainer/telnyx.net/3.1.0/telnyx.net.3.1.0.nupkg', BASE)
assert hashlib.sha256(BASE.read_bytes()).hexdigest() == BASE_SHA
project = ROOT / 'modern/src/Telnyx.Sdk/Telnyx.Sdk.csproj'
p = subprocess.run([str(DOTNET), 'build', str(project), '-c', 'Release', '-f', 'net8.0', '--nologo'], stdout=subprocess.PIPE, stderr=subprocess.STDOUT, text=True)
(OUT/'modern-build.log').write_text(p.stdout)
assert p.returncode == 0, 'modern build failed: see modern-build.log'
import tempfile
stage = Path(tempfile.mkdtemp(prefix='stage-', dir=OUT))
with zipfile.ZipFile(BASE) as z:
    for name in z.namelist():
        if name.startswith('lib/') or name.lower().endswith(('.png', '.md', '.txt')):
            dest = stage/name
            dest.parent.mkdir(parents=True, exist_ok=True)
            dest.write_bytes(z.read(name))
    ns = 'http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd'
    original = ET.fromstring(z.read('Telnyx.net.nuspec'))
    ns = original.tag.split('}')[0][1:]
    ET.register_namespace('', ns)
    meta = original.find('{'+ns+'}metadata')
    assert meta is not None
    version_element = meta.find('{'+ns+'}version')
    assert version_element is not None
    version_element.text = VERSION
    dependencies = meta.find('{'+ns+'}dependencies')
    assert dependencies is not None
    group = ET.SubElement(dependencies, '{'+ns+'}group', targetFramework='net8.0')
    for dep in dependencies[0]:
        ET.SubElement(group, '{'+ns+'}dependency', dict(dep.attrib))
    # net8 modern output uses platform STJ; preserve legacy dependencies only.
    files = ET.SubElement(original, '{'+ns+'}files')

net8 = stage/'lib/net8.0'
net8.mkdir(parents=True, exist_ok=True)
for ext in ['dll', 'xml']:
    shutil.copy2(stage/f'lib/netstandard2.1/Telnyx.net.{ext}', net8)
    shutil.copy2(project.parent/f'bin/Release/net8.0/Telnyx.Sdk.{ext}', net8)
for path in sorted(stage.rglob('*')):
    if path.is_file():
        ET.SubElement(files, '{'+ns+'}file', src=str(path), target=path.relative_to(stage).parent.as_posix())
(OUT/'Telnyx.net.nuspec').write_bytes(ET.tostring(original, encoding='utf-8', xml_declaration=True))
p = subprocess.run([str(DOTNET), 'pack', str(ROOT/'packaging/Telnyx.net.Package.csproj'), '-o', str(OUT), '--nologo'], stdout=subprocess.PIPE, stderr=subprocess.STDOUT, text=True)
(OUT/'pack.log').write_text(p.stdout)
assert p.returncode == 0, 'pack failed: see pack.log'
package = OUT/f'Telnyx.net.{VERSION}.nupkg'
report = inspect_package(package, True)
with zipfile.ZipFile(package) as z, zipfile.ZipFile(BASE) as baseline:
    for n in baseline.namelist():
        if n.startswith('lib/'):
            assert z.read(n) == baseline.read(n), n
    for ext in ['dll','xml']:
        assert z.read(f'lib/net8.0/Telnyx.net.{ext}') == baseline.read(f'lib/netstandard2.1/Telnyx.net.{ext}')
        assert z.read(f'lib/net8.0/Telnyx.Sdk.{ext}') == (net8/f'Telnyx.Sdk.{ext}').read_bytes()
report['release_accepted'] = False
report['blockers'] = ['authenticated exact-head generation provenance not provisioned', 'Windows runtime/packages.config gates pending', 'full release acceptance and independent review pending']
(OUT/'manifest.json').write_text(json.dumps(report, indent=2))
print(package)
