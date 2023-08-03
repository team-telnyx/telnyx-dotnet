using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.MobileOperatorNetworks;
using Telnyx.net.Services.Wireless.MobileOperatorNetworks;

namespace Telnyx.Example
{
    public class MobileOperatorNetworksExample
    {
        private readonly MobileOperatorNetworksService service = new MobileOperatorNetworksService();

        public TelnyxList<MobileOperatorNetworksRecord> List()
        {
            TelnyxList<MobileOperatorNetworksRecord> result = new TelnyxList<MobileOperatorNetworksRecord>();
            ListMobileOperatorNetworksOptions listOptions = new ListMobileOperatorNetworksOptions
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

        public async Task<TelnyxList<MobileOperatorNetworksRecord>> ListAsync()
        {
            TelnyxList<MobileOperatorNetworksRecord> result = new TelnyxList<MobileOperatorNetworksRecord>();
            ListMobileOperatorNetworksOptions listOptions = new ListMobileOperatorNetworksOptions
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
