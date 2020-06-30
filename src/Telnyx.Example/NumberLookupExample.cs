using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.NumberLookup;
using Telnyx.net.Services;

namespace Telnyx.Example
{
    public class NumberLookupExample
    {
        private readonly NumberLookupService service = new NumberLookupService();

        public TelnyxList<NumberLookupRecord> List()
        {
            TelnyxList<NumberLookupRecord> list = new TelnyxList<NumberLookupRecord>();
            NumberLookupRecordListOptions options = new NumberLookupRecordListOptions
            {
                PhoneNumber = "+18665552368",
                Type = "undefined"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                list = service.List(options);
                Console.WriteLine(JsonConvert.SerializeObject(list));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return list;
        }

        public async Task<TelnyxList<NumberLookupRecord>> ListAsync()
        {
            TelnyxList<NumberLookupRecord> list = new TelnyxList<NumberLookupRecord>();
            NumberLookupRecordListOptions options = new NumberLookupRecordListOptions
            {
                PhoneNumber = "+18665552368",
                Type = "undefined"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                list = await service.ListAsync(options, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(list));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return list;
        }
    }
}
