using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.WDRReports;
using Telnyx.net.Services.Wireless.WDRReports;

namespace Telnyx.Example
{
    public class WDRReportsExample
    {
        private readonly WDRReportsService service = new WDRReportsService();

        private const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public WDRReportsRecord Get()
        {
            WDRReportsRecord result = new WDRReportsRecord();

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

        public async Task<WDRReportsRecord> GetAsync()
        {
            WDRReportsRecord result = new WDRReportsRecord();

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

        public TelnyxList<WDRReportsRecord> List()
        {
            TelnyxList<WDRReportsRecord> result = new TelnyxList<WDRReportsRecord>();
            ListOptions listOptions = new ListOptions
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

        public async Task<TelnyxList<WDRReportsRecord>> ListAsync()
        {
            TelnyxList<WDRReportsRecord> result = new TelnyxList<WDRReportsRecord>();
            ListOptions listOptions = new ListOptions
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

        public WDRReportsRecord Create()
        {
            WDRReportsRecord result = new WDRReportsRecord();
            CreateWDRReportsOptions createOptions = new CreateWDRReportsOptions
            {
                EndTime = "2018-02-02T22:25:27.521Z",
                StartTime = "2018-02-02T22:25:27.521Z"
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOptions));

            try
            {
                result = service.Create(createOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WDRReportsRecord> CreateAsync()
        {
            WDRReportsRecord result = new WDRReportsRecord();
            CreateWDRReportsOptions createOptions = new CreateWDRReportsOptions
            {
                EndTime = "2018-02-02T22:25:27.521Z",
                StartTime = "2018-02-02T22:25:27.521Z"
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOptions));

            try
            {
                result = await service.CreateAsync(createOptions, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public WDRReportsRecord Delete()
        {
            WDRReportsRecord result = new WDRReportsRecord();

            try
            {
                result = service.Delete(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WDRReportsRecord> DeleteAsync()
        {
            WDRReportsRecord result = new WDRReportsRecord();

            try
            {
                result = await service.DeleteAsync(id, null);
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