# Modern SDK integration — diagnostic draft

`src/Telnyx.Sdk` contains generated SDK output, not generator implementation.
`Directory.Build.props` deliberately isolates modern build settings from the legacy
project. Do not hand-edit generated C# or its project file; fixes must be generated
upstream and imported byte-identically.

The local diagnostic package combines the unchanged registry 3.1.0 legacy assets
with the modern assembly in the net8.0 group. Modern netstandard2.0 is a compilation
check only, not an additional public package asset group.

Run diagnostics with .NET SDK 8.0.425 on PATH or set `DOTNET` to its executable:

```sh
python3 compat/build_diagnostic_candidate.py
python3 -m unittest discover -s compat/tests -v
python3 compat/run.py --candidate compat/diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg
python3 compat/verify_stj8_refresh.py
python3 compat/verify_runtime_regressions.py --candidate compat/diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg
# Install SDK 10.0.401 for this additional consumer-framework check:
python3 compat/verify_runtime_fallback.py --candidate compat/diagnostic-artifacts/Telnyx.net.4.0.0-preview.1.nupkg --dotnet /path/to/dotnet10
```

Runtime execution must be wrapped with OS egress denial using
`COMPAT_RUNTIME_PREFIX`. Hosted Linux uses a network namespace; package restore
and compilation run outside that namespace. The mixed runner requires a prefix.
Fixtures inject local handlers and dummy credentials; never run live API tests.

These are diagnostics, not release approval. Protected generation provenance,
verified build/pack binding, exact-artifact promotion, hosted Windows execution,
newer-runtime fallback and full API/feature acceptance must be evaluated on the
exact candidate. Local or hosted diagnostic success is not release approval. The
production pack entrypoint and publication workflow intentionally fail closed.

## Runtime behavior repaired in this draft

- Request timeout and cancellation remain active through response body consumption.
- Typed deserialization retains its linked cancellation source until it completes.
- Caller-owned upload streams remain open. Seekable uploads replay from their
  initial position; byte uploads replay identically. Non-seekable uploads stream
  once without buffering and surface the original HTTP error without retrying.
  Do not concurrently send the same mutable stream in multiple requests.
- IDs are literal path segments, encoded once. Bare `.` and `..` IDs are rejected
  before sending. Already-percent-encoded input remains literal, not pre-decoded.
- Numeric-array query values use invariant JSON numeric text.

The regression runner restores the exact candidate into an isolated NuGet cache,
checks its bytes and selected runtime assembly, and executes fake-handler public
API probes under mandatory OS egress denial. It never contacts the real API.
The root SDK pin selects serviced SourceLink tooling; the generated library no
longer overrides that tooling with the vulnerable SourceLink 8.0.0 package.
