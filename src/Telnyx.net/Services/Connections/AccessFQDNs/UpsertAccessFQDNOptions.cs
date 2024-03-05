namespace Telnyx.net.Services.Connections.FQDNs
{
    using Newtonsoft.Json;

    public class UpsertAccessFQDNOptions : BaseOptions
    {
 
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; } = null;

        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


    }
}
