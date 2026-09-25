param([Parameter(Mandatory=$true)][string]$Candidate, [string]$Target = 'net452')
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
if ($Target -notin @('net45','net452','net461','net462','net472','net48')) { throw 'Unsupported target' }
$Candidate = (Resolve-Path $Candidate).Path
$Root = $PSScriptRoot
$Work = Join-Path $Root "reports/windows/$Target"
New-Item -ItemType Directory -Force $Work | Out-Null
$Feed = Split-Path $Candidate
$Hash = (Get-FileHash $Candidate -Algorithm SHA256).Hash
function Invoke-Checked([string]$Command, [string[]]$Arguments) {
  & $Command @Arguments 2>&1 | Tee-Object -FilePath (Join-Path $Work 'commands.log') -Append
  if ($LASTEXITCODE -ne 0) { throw "$Command failed: $LASTEXITCODE" }
}
# Restore/build have network access only for package acquisition. Runtime has no sockets.
foreach ($Version in @('3.1.0','4.0.0-preview.1')) {
  $Packages = Join-Path $Work "packages-$Version"
  Invoke-Checked nuget @('install','Telnyx.net','-Version',$Version,'-Framework',$Target,'-OutputDirectory',$Packages,'-Source',"$Feed;https://api.nuget.org/v3/index.json",'-NonInteractive','-DirectDownload','-NoCache')
  $Entries = Get-ChildItem $Packages -Directory | ForEach-Object {
    $Spec = Get-ChildItem $_.FullName -Filter '*.nuspec' | Select-Object -First 1
    if (-not $Spec) { throw 'Missing installed nuspec' }
    [xml]$Xml = Get-Content $Spec.FullName
    '<package id="' + $Xml.package.metadata.id + '" version="' + $Xml.package.metadata.version + '" targetFramework="' + $Target + '" />'
  }
  $Config = Join-Path $Work "packages.$Version.config"
  ('<packages>' + ($Entries -join '') + '</packages>') | Set-Content $Config
  Invoke-Checked nuget @('restore',$Config,'-PackagesDirectory',$Packages,'-Source',"$Feed;https://api.nuget.org/v3/index.json",'-NonInteractive')
}
# Use a conventional non-SDK packages.config project; never reference modern DLLs.
$BasePackages = Join-Path $Work 'packages-3.1.0'
$Refs = @('<Reference Include="System" />','<Reference Include="System.Core" />','<Reference Include="System.Net.Http" />')
foreach ($Package in (Get-ChildItem $BasePackages -Directory)) {
  $Lib = Join-Path $Package.FullName 'lib'
  $Chosen = $null
  foreach ($Tfm in @($Target,'net452','net45','net40','net35','net20')) {
    if ($Target -eq 'net45' -and $Tfm -eq 'net452') { continue }
    $Dir = Join-Path $Lib $Tfm
    if (Test-Path $Dir) { $Chosen = $Dir; break }
  }
  if (-not $Chosen -and (Test-Path $Lib)) { $Chosen = $Lib }
  if ($Chosen) {
    foreach ($Dll in (Get-ChildItem $Chosen -Filter '*.dll')) {
      $Refs += '<Reference Include="' + $Dll.BaseName + '"><HintPath>' + $Dll.FullName + '</HintPath><Private>True</Private></Reference>'
    }
  }
}
$Framework = @{net45='v4.5';net452='v4.5.2';net461='v4.6.1';net462='v4.6.2';net472='v4.7.2';net48='v4.8'}[$Target]
Copy-Item (Join-Path $Root 'LegacyContract.cs') $Work
Copy-Item (Join-Path $Root 'Runtime.cs') (Join-Path $Work 'Program.cs')
Copy-Item (Join-Path $Work 'packages.3.1.0.config') (Join-Path $Work 'packages.config')
'<configuration><startup><supportedRuntime version="v4.0" /></startup></configuration>' | Set-Content (Join-Path $Work 'app.config')
$Project = '<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003"><PropertyGroup><OutputType>Exe</OutputType><AssemblyName>Consumer</AssemblyName><TargetFrameworkVersion>' + $Framework + '</TargetFrameworkVersion><OutputPath>bin\</OutputPath><AutoGenerateBindingRedirects>false</AutoGenerateBindingRedirects><LangVersion>latest</LangVersion></PropertyGroup><ItemGroup>' + ($Refs -join '') + '<Compile Include="Program.cs" /><Compile Include="LegacyContract.cs" /><None Include="app.config" /><None Include="packages.config" /></ItemGroup><Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" /></Project>'
$Project | Set-Content (Join-Path $Work 'Consumer.csproj')
$ReferencePackages = Join-Path $Work 'reference-assemblies'
Invoke-Checked nuget @('install',"Microsoft.NETFramework.ReferenceAssemblies.$Target",'-Version','1.0.3','-OutputDirectory',$ReferencePackages,'-Source','https://api.nuget.org/v3/index.json','-NonInteractive')
$ReferencePath = Join-Path $ReferencePackages "Microsoft.NETFramework.ReferenceAssemblies.$Target.1.0.3/build/.NETFramework/$Framework"
if (-not (Test-Path $ReferencePath)) { throw 'Pinned framework references missing' }
Invoke-Checked msbuild @((Join-Path $Work 'Consumer.csproj'),'/t:Build','/p:Configuration=Release',"/p:FrameworkPathOverride=$ReferencePath",'/nologo')
$Exe = Join-Path $Work 'bin/Consumer.exe'
$Original = (Get-FileHash $Exe).Hash
$AppConfig = (Get-FileHash "$Exe.config").Hash
# OS egress denial complements the injected no-socket handler.
$Rule = New-NetFirewallRule -DisplayName "Telnyx diagnostic $Target" -Direction Outbound -Program $Exe -Action Block -Enabled True
Invoke-Checked $Exe @()
$Selected = if ($Target -eq 'net45') {'net45'} else {'net452'}
$NewDll = Join-Path $Work "packages-4.0.0-preview.1/Telnyx.net.4.0.0-preview.1/lib/$Selected/Telnyx.net.dll"
Copy-Item $NewDll (Join-Path $Work 'bin/Telnyx.net.dll') -Force
Invoke-Checked $Exe @()
if ((Get-FileHash $Exe).Hash -ne $Original -or (Get-FileHash "$Exe.config").Hash -ne $AppConfig) { throw 'Consumer or redirects changed' }
if ((Get-FileHash $Candidate -Algorithm SHA256).Hash -ne $Hash) { throw 'Candidate mutated' }
@{target=$Target; installedFrameworkRelease=(Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full').Release; candidateSha256=$Hash; consumerSha256=$Original; releaseAccepted=$false; result='PASS'; limitation='Windows hosted installed CLR, not historical CLR certification; package install/restore and unrecompiled swap, not Visual Studio update command'} | ConvertTo-Json | Set-Content (Join-Path $Work 'results.json')
