# Synthetic dynamic emergency address responses

These are deliberately synthetic, schema-valid HTTP response fixtures, not captured API responses or canonical examples. `W` is one allowed string, independent of request input. Response IDs intentionally differ from the retrieve request ID. Both fixtures keep ISO timestamps on the wire; existing SDK list/retrieve assertions cover their distinct deserialization behavior.

Validate against the frozen specification (no schema modifications):

```sh
uv run --with jsonschema==4.23.0 python validate.py /tmp/pr93-legacy-mock-spec.json
```

The validator rejects any spec other than SHA256 `4e19686e312db8ffbb28f7b36912bbaef95aae50c816ad09bb9f4e5238110c1c` and uses each exact GET/200 response envelope with format checking. Current-spec mock integration controls are additional coverage, not replacements for the four full-field response tests.
