using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.VirtualCrossConnectCloudRegions
{
    public class VirtualCrossConnectCloudRegion : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("cloud_provider")]
        public string CloudProvider { get; set; }

        [JsonProperty("cloud_region")]
        public string CloudRegion { get; set; }

        [JsonProperty("bandwidth_mbps")]
        public int[] BandwidthMbps { get; set; }
    }
}
