# Legacy API contract test boundaries

The legacy assembly predates the current API contract. Its tests now distinguish
three kinds of evidence; none proves that a retired endpoint exists in production.

## Current contract

`.github/workflows/dotnet.yml` retains its immutable current OpenAPI revision and
SHA-256. Normal legacy integration tests continue to use that contract on loopback
port 12111. `CurrentContractCompatibilityTest` additionally sends the public SDK's
requests to that current mock and checks raw response shapes/statuses for cases
with separate historical coverage. Expected incompatibility tests document a
limitation; their success is not a claim that the SDK operation works today.

## Explicit historical compatibility

`HistoricalContractTest` or `HistoricalContractScope` opts a test into a **separate**
Prism server on loopback port 4013. There is no automatic fallback after a current
request fails. The bootstrap checks both digests before installing dependencies,
refuses occupied ports, verifies all server processes and health checks, and
cleans up all child servers on bootstrap failure. Successful bootstrap deliberately
leaves them running for later CI steps; ephemeral hosted-runner teardown ends them.

Historical source:
- Repository: `team-telnyx/openapi`
- Revision: `1d97a787b3c88edce00428076ec0c236392a3f18`
- File: `openapi/spec3.json`
- SHA-256: `02d40213df0e3401e4720b8924fe4f2d56314b630ec9d57a5f13fb3132e05482`

This archived contract covers retired endpoints such as number-order documents,
batch MDR reports, credential tags, shared partner campaigns, virtual cross-connect
cloud regions, allowed IPs, call registration and network preferences. It also
preserves response compatibility tests for managed-account credentials and detailed
messaging metrics, which the current contract no longer supplies in those shapes.

Original test identities, assertions and existing skips are retained. Opting a test
into this archive does not excuse a route, request or response-model defect: those
continue to fail until actually repaired. No current spec was relaxed or replaced.

## Deterministic HTTP response fixtures

Dynamic emergency address response tests use scoped synthetic HTTP boundary
fixtures validated against the current schema—not captured API responses or
canonical examples. This preserves exact-value
assertions instead of relying on Prism's generated sample UUID/text. The fixture
validates the request method, path and expected query. Independent tests cover
both response fixtures and normal current-mock service behavior.

## Package and provenance limits

These tests compile legacy source; existing diagnostic package-compatibility jobs
still exercise historical legacy binaries. That is a separate evidence boundary.
The generation provenance check and publication quarantine remain fail-closed.
