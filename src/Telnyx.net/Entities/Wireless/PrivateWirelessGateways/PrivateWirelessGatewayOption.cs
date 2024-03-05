using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PrivateWirelessGateways
{
    public class PrivateWirelessGatewayOption : ListOptions
    {
        [JsonProperty("filter[name]")]
        public string Name { get; set; }

        [JsonProperty("filter[ip_range]")]
        public string IpRange { get; set; }

        [JsonProperty("filter[region_code]")]
        public string RegionCode { get; set; }

        [JsonProperty("filter[created_at]")]
        public string CreatedAt { get; set; }

        [JsonProperty("filter[updated_at]")]
        public string UpdatedAt { get; set; }
    }
}
