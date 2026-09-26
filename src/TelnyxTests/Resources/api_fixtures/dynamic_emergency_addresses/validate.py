"""Validate synthetic fixtures against the unchanged pinned operation schemas."""
import hashlib
import json
import sys
from pathlib import Path

from jsonschema import Draft202012Validator, FormatChecker
from referencing import Registry, Resource
from referencing.jsonschema import DRAFT202012

raw = Path(sys.argv[1]).read_bytes()
expected = "4e19686e312db8ffbb28f7b36912bbaef95aae50c816ad09bb9f4e5238110c1c"
if hashlib.sha256(raw).hexdigest() != expected:
    raise SystemExit("Specification SHA256 mismatch")
spec = json.loads(raw)
uri = "urn:telnyx:dynamic-address-spec"
registry = Registry().with_resource(uri, Resource.from_contents(
    spec, default_specification=DRAFT202012))
for name, path in [("list", "/dynamic_emergency_addresses"),
                   ("retrieve", "/dynamic_emergency_addresses/{id}")]:
    pointer = path.replace("~", "~0").replace("/", "~1")
    schema = {"$ref": uri + "#/paths/" + pointer + "/get/responses/200/content/application~1json/schema"}
    payload = json.loads(Path(__file__).with_name(name + ".json").read_text())
    validator = Draft202012Validator(schema, registry=registry, format_checker=FormatChecker())
    validator.validate(payload)
    records = payload["data"] if name == "list" else [payload["data"]]
    assert len(records) == 1
    for record in records:
        for field in ("created_at", "updated_at"):
            assert record[field] == "2018-02-02T22:25:27.521Z"
            FormatChecker().check(record[field], "date-time")
    # Negative control: required address data cannot silently disappear.
    del records[0]["street_name"]
    assert not validator.is_valid(payload)
    print(f"PASS {name}: GET {path} 200; ISO wire dates; missing street_name rejected")
print("Pinned specification SHA256: " + expected)
