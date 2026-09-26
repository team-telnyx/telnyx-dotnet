#!/usr/bin/env bash
# Sourced by CI so bootstrap failures stop the job before tests run.
set -euo pipefail
: "${TELNYX_MOCK_OPEN_API_URI:?immutable spec URL required}"
: "${TELNYX_MOCK_SPEC_SHA256:?spec digest required}"
: "${TELNYX_MOCK_PROXY_REVISION:?proxy revision required}"
mock_root="$(mktemp -d)"
log_dir="${RUNNER_TEMP:-/tmp}/telnyx-dotnet-mock-logs"
mkdir -p "$log_dir"
curl --fail --silent --show-error --location "$TELNYX_MOCK_OPEN_API_URI" -o "$mock_root/spec.json"
python3 - "$mock_root/spec.json" "$TELNYX_MOCK_SPEC_SHA256" <<'PY'
import hashlib, pathlib, sys
actual = hashlib.sha256(pathlib.Path(sys.argv[1]).read_bytes()).hexdigest()
if actual != sys.argv[2]:
    raise SystemExit('Mock spec digest mismatch: ' + actual)
PY
# Never mistake another process's health response for our newly started mock.
python3 - <<'PY'
import socket
for port in (4010, 12111):
    with socket.socket() as sock:
        sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        sock.bind(('127.0.0.1', port))
PY
prism_pid=''
proxy_pid=''
cleanup_failed_mock() {
    local pid
    for pid in "$prism_pid" "$proxy_pid"; do
        if [ -n "$pid" ]; then kill "$pid" 2>/dev/null || true; fi
    done
}
trap cleanup_failed_mock EXIT
mkdir -p "$mock_root/prism"
cp .github/mock/package.json .github/mock/package-lock.json "$mock_root/prism/"
(cd "$mock_root/prism" && npm ci --ignore-scripts)
# Preserve absence of optional deepObject values instead of inventing []/{}.
# Exact decoder bytes are checked; schema validation remains enabled.
decoder="$mock_root/prism/node_modules/@stoplight/prism-http/dist/validator/deserializers/style/deepObject.js"
node .github/mock/patch-deep-object.cjs "$decoder"
node .github/mock/test-deep-object.cjs "$decoder"
sampler="$mock_root/prism/node_modules/@stoplight/json-schema-sampler"
node .github/mock/patch-int64-sample.cjs "$sampler/dist/json-schema-sampler.js"
node .github/mock/test-int64-sample.cjs "$sampler"
node "$mock_root/prism/node_modules/@stoplight/prism-cli/dist/index.js" mock "$mock_root/spec.json" --host 127.0.0.1 --port 4010 > "$log_dir/prism.log" 2>&1 &
prism_pid=$!
git clone --no-checkout https://github.com/team-telnyx/telnyx-prism-mock.git "$mock_root/proxy"
git -C "$mock_root/proxy" checkout --detach "$TELNYX_MOCK_PROXY_REVISION"
# This audited source patch confines the pinned proxy and its upstream to loopback.
python3 - "$mock_root/proxy/proxy/index.js" <<'PY'
import pathlib, sys
path = pathlib.Path(sys.argv[1])
source = path.read_text()
for old, new in (("const HOST = '0.0.0.0';", "const HOST = '127.0.0.1';"),
                 ("'http://0.0.0.0:4010'", "'http://127.0.0.1:4010'")):
    if source.count(old) != 1:
        raise SystemExit('Unexpected pinned proxy source')
    source = source.replace(old, new)
path.write_text(source)
PY
npx --yes yarn@1.22.22 --cwd "$mock_root/proxy/proxy" install --frozen-lockfile --ignore-scripts
node "$mock_root/proxy/proxy/index.js" > "$log_dir/proxy.log" 2>&1 &
proxy_pid=$!
ready=false
for _ in {1..30}; do
    kill -0 "$prism_pid" "$proxy_pid" || { printf 'Mock exited; inspect %s\n' "$log_dir" >&2; exit 1; }
    if curl --fail --silent --show-error --max-time 2 -H 'Authorization: Bearer TEST_ONLY' http://127.0.0.1:12111/v2/balance -o "$log_dir/readiness.json"; then
        ready=true
        break
    fi
    sleep 1
done
if [ "$ready" != true ]; then
    printf 'Mock readiness failed; inspect %s\n' "$log_dir" >&2
    exit 1
fi
kill -0 "$prism_pid" "$proxy_pid"
trap - EXIT
