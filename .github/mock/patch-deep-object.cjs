// Narrow, fail-closed patch for the locked Prism 4.10.5 deepObject decoder.
// It invents [] and {} for absent optional properties, causing false minItems
// violations. Do not alter schemas, supplied values, or validation rules.
const fs = require('node:fs');
const crypto = require('node:crypto');
const filename = process.argv[2];
if (!filename) throw new Error('Expected locked deepObject.js path');
const source = fs.readFileSync(filename, 'utf8');
const expected = 'aad549a8e08fa15cf7c8cfcdab95c1370eeb9ff8c122c7ffdad12489cb811eac';
if (crypto.createHash('sha256').update(source).digest('hex') !== expected) {
  throw new Error('Unexpected Prism decoder bytes; re-audit before updating patch');
}
const anchor = '    function construct(currentPath, def) {\n';
const replacement = anchor + `        const key = resolve(currentPath);
        const supplied = Object.keys(parameters).some(k => k === key || k.startsWith(key + '['));
        if (!supplied) return undefined;
`;
if (source.split(anchor).length !== 2) throw new Error('Ambiguous decoder patch anchor');
fs.writeFileSync(filename, source.replace(anchor, replacement));
