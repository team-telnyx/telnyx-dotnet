namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx;

    public class GlobalIPs : TelnyxEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("record_type")]
        public bool RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("ports")]
        public PortInfo Ports { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
