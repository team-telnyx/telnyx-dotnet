using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PrivateWirelessGateways
{
    public class UpsertPrivateWirelessGateway : BaseOptions
    {
        [JsonProperty("network_id")]
        public Guid NetworkId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
