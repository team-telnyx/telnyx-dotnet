namespace Telnyx.net.Entities.Connections.FQDNs
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class FQDN : TelnyxEntity, IHasId
    {
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("dns_record_type")]
        public string DnsRecordType { get; set; }

        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
