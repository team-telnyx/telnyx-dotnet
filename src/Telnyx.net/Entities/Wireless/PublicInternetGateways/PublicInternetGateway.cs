using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PublicInternetGateways
{
    public class PublicInternetGateway : TelnyxEntity
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
        public InterfaceStatus Status { get; set; }

        [JsonProperty("public_ip")]
        public string PublicIp { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }
    }
    public class InterfaceStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Region
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
