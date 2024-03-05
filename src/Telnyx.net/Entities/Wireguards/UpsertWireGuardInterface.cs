using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces
{
    public class UpsertWireGuardInterface : BaseOptions
    {
        [JsonProperty("network_id")]
        public Guid NetworkId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("enable_sip_trunking")]
        public bool EnableSipTrunking { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
    }
}
