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

        public Task<TelnyxList<NumberLookupRecord>> ListAsync()
        {
            NumberLookupRecordListOptions options = new NumberLookupRecordListOptions
            {
                PhoneNumber = "+18665552368",
                Type = "undefined"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                var list = service.ListAsync(options, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(list));
                return list;
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return null;
        }
    }
}
