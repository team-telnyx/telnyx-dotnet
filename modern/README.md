# Modern SDK integration — diagnostic draft

`src/Telnyx.Sdk` contains generated SDK output, not generator implementation.
`Directory.Build.props` deliberately isolates modern build settings from the legacy
project. Do not hand-edit generated C# or its project file; fixes must be generated
upstream and imported byte-identically.

The local diagnostic package combines the unchanged registry 3.1.0 legacy assets
with the modern assembly in the net8.0 group. Modern netstandard2.0 is a compilation
check only, not an additional public package asset group.

Run diagnostics with .NET SDK 8.0.423 on PATH or set `DOTNET` to its executable:

```sh
python3 compat/build_diagnostic_candidate.py
python3 -m unittest discover -s compat/tests -v
python3 compat/run.py --candidate compat/diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg
python3 compat/verify_stj8_refresh.py
```

Runtime execution must be wrapped with OS egress denial using
`COMPAT_RUNTIME_PREFIX`. Hosted Linux uses a network namespace; package restore
and compilation run outside that namespace. The mixed runner requires a prefix.
Fixtures inject local handlers and dummy credentials; never run live API tests.

These are diagnostics, not release approval. Protected generation provenance,
verified build/pack binding, exact-artifact promotion, hosted Windows execution,
newer-runtime fallback and full API/feature acceptance remain outstanding. The
production pack entrypoint and publication workflow intentionally fail closed.
