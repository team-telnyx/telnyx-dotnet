namespace Telnyx.net.Services.Connections.IPConnections
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class UpsertIPConnectionOptions : UpsertConnectionOptions
    {
        /// <summary>
        /// One of UDP, TLS, or TCP. Applies only to connections with IP authentication or FQDN authentication.
        /// </summary>
        [JsonProperty("transport_protocol")]
        public TransportProtocol? TransportProtocol { get; set; } = Entities.Enum.TransportProtocol.UDP;
    }
}
