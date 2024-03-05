using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Telnyx.net.Entities.VirtualCrossConnects
{
    public class UpsertVirtualCrossConnect : BaseOptions
    {
        [JsonProperty("network_id")]
        public Guid NetworkId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cloud_provider")]
        public string CloudProvider { get; set; }

        [JsonProperty("cloud_region")]
        public string CloudRegion { get; set; }

        [JsonProperty("bgp_asn")]
        public int BgpAsn { get; set; }

        [JsonProperty("bandwidth_mbps")]
        public int BandwidthMbps { get; set; }

        [JsonProperty("primary_cloud_account_id")]
        public string PrimaryCloudAccountId { get; set; }

        [JsonProperty("primary_telnyx_ip")]
        public string PrimaryTelnyxIp { get; set; }

        [JsonProperty("primary_cloud_ip")]
        public string PrimaryCloudIp { get; set; }

        [JsonProperty("primary_bgp_key")]
        public string PrimaryBgpKey { get; set; }

        [JsonProperty("secondary_cloud_account_id")]
        public string SecondaryCloudAccountId { get; set; }

        [JsonProperty("secondary_telnyx_ip")]
        public string SecondaryTelnyxIp { get; set; }

        [JsonProperty("secondary_cloud_ip")]
        public string SecondaryCloudIp { get; set; }

        [JsonProperty("secondary_bgp_key")]
        public string SecondaryBgpKey { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
    }
}
