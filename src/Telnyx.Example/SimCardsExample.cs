using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless;
using Telnyx.net.Entities.Wireless.SimCards;
using Telnyx.net.Services.Wireless.SimCards;

namespace Telnyx.Example
{
    public class SimCardsExample
    {
        private readonly SimCardsService service = new SimCardsService();
        private readonly SimCardEnableService simCardEnableService = new SimCardEnableService();

        private const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardRecord Get()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

                result = service.Get(id, baseOptions, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> GetAsync()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

                result = await service.GetAsync(id, baseOptions, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxList<SimCardRecord> List()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            ListSimCardOptions listOptions = new ListSimCardOptions
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

        public async Task<TelnyxList<SimCardRecord>> ListAsync()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            ListSimCardOptions listOptions = new ListSimCardOptions
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

        public SimCardRecord Delete()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

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

        public async Task<SimCardRecord> DeleteAsync()
        {
            SimCardRecord result = new SimCardRecord();

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

        public SimCardRecord Enable()
        {
            SimCardRecord result = new SimCardRecord();

            BaseOptions baseOptions = new BaseOptions();

            try
            {
                result = simCardEnableService.Create(id, baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> EnableAsync()
        {
            SimCardRecord result = new SimCardRecord();

            BaseOptions baseOptions = new BaseOptions();

            try
            {
                result = await simCardEnableService.CreateAsync(id, baseOptions);
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
