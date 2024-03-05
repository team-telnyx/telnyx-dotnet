using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.VirtualCrossConnects
{
    public class VirtualCrossConnect : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("network_id")]
        public Guid NetworkId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("cloud_provider")]
        public string CloudProvider { get; set; }

        [JsonProperty("cloud_region")]
        public string CloudRegion { get; set; }

        [JsonProperty("bgp_asn")]
        public int BgpAsn { get; set; }

        [JsonProperty("bandwidth_mbps")]
        public int? BandwidthMbps { get; set; }

        [JsonProperty("primary_enabled")]
        public bool PrimaryEnabled { get; set; }

        [JsonProperty("primary_cloud_account_id")]
        public string PrimaryCloudAccountId { get; set; }

        [JsonProperty("primary_telnyx_ip")]
        public string PrimaryTelnyxIp { get; set; }

        [JsonProperty("primary_cloud_ip")]
        public string PrimaryCloudIp { get; set; }

        [JsonProperty("primary_bgp_key")]
        public string PrimaryBgpKey { get; set; }

        [JsonProperty("secondary_enabled")]
        public bool SecondaryEnabled { get; set; }

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

        [JsonProperty("primary_routing_announcement")]
        public bool PrimaryRoutingAnnouncement { get; set; }

        [JsonProperty("secondary_routing_announcement")]
        public bool SecondaryRoutingAnnouncement { get; set; }

        [JsonProperty("region")]
        public InterfaceRegion Region { get; set; }
    }
    public class InterfaceRegion
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
