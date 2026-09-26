// Keep locked Prism's default int64 sample inside the wire type's range.
// JS rounds -2**63 to text -9223372036854776000, outside signed int64.
// Select zero only when ALL numeric constraints admit it. Validation schemas
// and explicit examples are unchanged; this affects generated mock data only.
const fs = require('node:fs');
const crypto = require('node:crypto');
const filename = process.argv[2];
const source = fs.readFileSync(filename, 'utf8');
if (crypto.createHash('sha256').update(source).digest('hex') !== '3352ed94611ff84fdb6e05d8ca7db6341f975a9bc5cc9bc954d3e5a02a56fd40') {
  throw new Error('Unexpected sampler bytes; re-audit patch');
}
const anchor = 'function sampleNumber(schema) {\n';
const replacement = anchor + `  if (schema.type === 'integer' && schema.format === 'int64'
      && schema.minimum === -(2 ** 63) && schema.maximum === 2 ** 63 - 1
      && !('exclusiveMinimum' in schema) && !('exclusiveMaximum' in schema)) {
    return 0;
  }
`;
if (source.split(anchor).length !== 2) throw new Error('Ambiguous number sampler anchor');
fs.writeFileSync(filename, source.replace(anchor, replacement));
