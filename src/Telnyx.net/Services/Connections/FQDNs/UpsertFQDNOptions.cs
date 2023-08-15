namespace Telnyx.net.Services.Connections.FQDNs
{
    using Newtonsoft.Json;

    public class UpsertFQDNOptions : BaseOptions
    {
        /// <summary>
        /// ID of the FQDN connection to which this IP should be attached.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; } = null;

        /// <summary>
        /// FQDN represented by the resource. Example: "example.com".
        /// </summary>
        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        /// <summary>
        /// Port to use when connecting to this FQDN.
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; } = 5060;

        /// <summary>
        /// The DNS record type for the FQDN. 
        /// For cases where a port is not set, the DNS record type must be 'srv'. 
        /// For cases where a port is set, the DNS record type must be 'a'. 
        /// If the DNS record type is 'a' and a port is not specified, 5060 will be used.
        /// </summary>
        [JsonProperty("dns_record_type")]
        public string DNSRecordType { get; set; }
    }
}
