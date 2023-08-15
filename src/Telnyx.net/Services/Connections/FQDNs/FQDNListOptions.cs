namespace Telnyx.net.Services.Connections.FQDNs
{
    using Newtonsoft.Json;

    public class FQDNListOptions : ListOptions
    {
        /// <summary>
        /// ID of the FQDN connection to which the FQDN belongs.
        /// </summary>
        [JsonProperty("filter[connection_id]")]
        public string ConnectionId { get; set; } = null;

        /// <summary>
        /// FQDN represented by the resource.
        /// </summary>
        [JsonProperty("filter[fqdn]")]
        public string Fqdn { get; set; }

        /// <summary>
        /// Port to use when connecting to the FQDN. Example: 5060.
        /// </summary>
        [JsonProperty("filter[port]")]
        public int? Port { get; set; }

        /// <summary>
        /// DNS record type used by the FQDN. Example: "a".
        /// </summary>
        [JsonProperty("filter[dns_record_type]")]
        public string DNSRecordType { get; set; }
    }
}
