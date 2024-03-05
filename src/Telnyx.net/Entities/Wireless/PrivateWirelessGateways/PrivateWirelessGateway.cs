using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PrivateWirelessGateways
{
    public class PrivateWirelessGateway : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("network_id")]
        public Guid NetworkId { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("status")]
        public PrivateWirelessGatewayStatus Status { get; set; }

        [JsonProperty("ip_range")]
        public string IpRange { get; set; }

        [JsonProperty("assigned_resources")]
        public PrivateWirelessGatewayAssignedResource[] AssignedResources { get; set; }
    }
    public class PrivateWirelessGatewayStatus
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }

    public class PrivateWirelessGatewayAssignedResource
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
