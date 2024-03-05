
namespace Telnyx.net.Entities.Connections.AccessFQDNs
{
    using System;
    using Newtonsoft.Json;

    public class AccessFQDN : TelnyxEntity,IHasId
    {
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
