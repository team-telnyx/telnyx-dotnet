using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.OTAUpdates;
using Telnyx.net.Services.Wireless.OTAUpdatesService;

namespace Telnyx.Example
{
    public class OTAUpdatesExample
    {
        private readonly OTAUpdatesService service = new OTAUpdatesService();

        private const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public OTAUpdatesRecord Get()
        {
            OTAUpdatesRecord result = new OTAUpdatesRecord();

            try
            {
                result = service.Get(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<OTAUpdatesRecord> GetAsync()
        {
            OTAUpdatesRecord result = new OTAUpdatesRecord();

            try
            {
                result = await service.GetAsync(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxList<OTAUpdatesRecord> List()
        {
            TelnyxList<OTAUpdatesRecord> result = new TelnyxList<OTAUpdatesRecord>();
            ListOTAUpdatesOptions listOptions = new ListOTAUpdatesOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<TelnyxList<OTAUpdatesRecord>> ListAsync()
        {
            TelnyxList<OTAUpdatesRecord> result = new TelnyxList<OTAUpdatesRecord>();
            ListOTAUpdatesOptions listOptions = new ListOTAUpdatesOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = await service.ListAsync(listOptions, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }
    }
}