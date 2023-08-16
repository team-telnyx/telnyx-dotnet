using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.NumberLookup;
using Telnyx.net.Services;

namespace Telnyx.Example
{
    public class NumberLookupExample
    {
        private readonly NumberLookupService service = new NumberLookupService();
        private const string phoneNumber = "+18665552368";
        public NumberLookupRecord Get()
        {
            NumberLookupRecord record = new NumberLookupRecord();
            NumberLookupRecordOptions options = new NumberLookupRecordOptions
            {
                Type = "undefined"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                record = service.Get(phoneNumber, options);
                Console.WriteLine(JsonConvert.SerializeObject(record));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return record;
        }

        public async Task<NumberLookupRecord> GetAsync()
        {
            NumberLookupRecord record = new NumberLookupRecord();
            NumberLookupRecordOptions options = new NumberLookupRecordOptions
            {
                Type = "undefined"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                record = await service.GetAsync(phoneNumber, options, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(record));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return record;
        }
    }
}
