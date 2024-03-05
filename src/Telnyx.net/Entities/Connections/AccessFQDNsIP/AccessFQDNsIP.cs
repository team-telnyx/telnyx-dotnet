
namespace Telnyx.net.Entities.Connections.AccessFQDNsIP
{
    using System;
    using Newtonsoft.Json;

    public class AccessFQDNsIP : TelnyxEntity
    {
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
