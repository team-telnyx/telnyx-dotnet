// Regression controls for Prism's optional deepObject property handling.
const assert = require('node:assert/strict');
const {deserializeDeepObjectStyle: decode} = require(process.argv[2]);
const schema = {type: 'object', properties: {
  status: {type: 'array', minItems: 1, items: {type: 'string'}},
  page: {type: 'object', properties: {size: {type: 'integer'}}},
  type: {type: 'string'},
}};
assert.equal(decode('filter', {}, schema), undefined, 'omitted filter must stay absent');
const present = decode('filter', {'filter[type]': 'update_phone_numbers'}, schema);
assert.equal(present.type, 'update_phone_numbers');
assert.equal(present.status, undefined, 'absent optional array must not become []');
assert.equal(present.page, undefined, 'absent optional object must stay absent');
assert.deepEqual(decode('filter', {'filter[status][0]': 'pending'}, schema).status, ['pending']);
assert.equal(decode('filter', {'filter[page][size]': '2'}, schema).page.size, '2');
assert.equal(decode('filter', {'filter[type]': ''}, schema).type, '', 'explicit empty scalar must survive validation');
assert.equal(decode('filter', {'filtering[type]': 'x'}, schema), undefined, 'prefix must be delimited');
// Exercise the installed Prism query validator (including its real AJV), not
// just decoder output. Resolve beside the supplied decoder to test that exact
// installation and avoid accidentally validating against a different Prism.
const path = require('node:path');
const {validate} = require(path.resolve(path.dirname(process.argv[2]), '../../validators/query.js'));
const validationSchema = {type: 'object', properties: {
  status: {type: 'array', minItems: 1, items: {type: 'string', enum: ['pending', 'completed']}},
  page: {type: 'object', required: ['size'], properties: {
    size: {type: 'integer', minimum: 1},
  }},
  type: {type: 'string', enum: ['update_phone_numbers']},
}};
let validationControls = 0;
function check(label, parameters, filterSchema, required, expectedCode) {
  const result = validate(parameters, [{name: 'filter', style: 'deepObject',
    explode: true, required, schema: filterSchema}]);
  assert.equal(result._tag, expectedCode ? 'Left' : 'Right', `${label}: ${JSON.stringify(result)}`);
  if (expectedCode) {
    assert.ok(result.left.some(error => error.code === expectedCode),
      `${label}: expected ${expectedCode}: ${JSON.stringify(result.left)}`);
  }
  validationControls++;
}
check('optional filter absent', {}, validationSchema, false);
check('present sibling leaves optional containers absent', {'filter[type]': 'update_phone_numbers'}, validationSchema, false);
check('valid indexed enum item', {'filter[status][0]': 'pending'}, validationSchema, false);
check('valid nested integer is coerced by Prism', {'filter[page][size]': '2'}, validationSchema, false);
check('missing required top-level filter', {}, validationSchema, true, 'required');
check('lookalike prefix cannot satisfy required filter', {'filtering[type]': 'update_phone_numbers'}, validationSchema, true, 'required');
check('missing required array without minItems still fails', {'filter[type]': 'update_phone_numbers'}, {
  type: 'object', required: ['status'], properties: {
    type: validationSchema.properties.type,
    status: {type: 'array', items: {type: 'string'}},
  },
}, false, 'required');
check('missing required nested object still fails', {'filter[type]': 'update_phone_numbers'}, {
  ...validationSchema, required: ['page'],
}, false, 'required');
check('present nested object missing required child', {'filter[page][other]': '2'}, validationSchema, false, 'required');
check('invalid supplied enum remains invalid', {'filter[type]': 'invalid'}, validationSchema, false, 'enum');
check('explicit empty scalar remains invalid', {'filter[type]': ''}, validationSchema, false, 'enum');
check('invalid array item remains invalid', {'filter[status][0]': 'invalid'}, validationSchema, false, 'enum');
check('explicit empty array item remains invalid', {'filter[status][0]': ''}, validationSchema, false, 'enum');
check('nonindexed empty array is not mistaken for absence', {'filter[status]': ''}, validationSchema, false, 'minItems');
check('invalid nested integer remains invalid', {'filter[page][size]': 'not-an-integer'}, validationSchema, false, 'type');
check('nested minimum still enforced', {'filter[page][size]': '0'}, validationSchema, false, 'minimum');
console.log(`deepObject decoder controls and ${validationControls} real Prism validation controls passed`);
