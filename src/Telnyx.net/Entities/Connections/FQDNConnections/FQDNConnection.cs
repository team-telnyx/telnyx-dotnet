namespace Telnyx.net.Entities.Connections.FQDNConnections
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class FQDNConnection : ConnectionBase
    {
        [JsonProperty("transport_protocol")]
        public TransportProtocol? TransportProtocol { get; set; } = Enum.TransportProtocol.UDP;
    }
}
