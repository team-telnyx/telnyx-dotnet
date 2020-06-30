using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Services.Connections.FQDNConnections;

namespace Telnyx.net.Services.Connections.IPConnections
{
    public class UpsertIPConnectionOptions : UpsertConnectionOptions
    {
        /// <summary>
        /// One of UDP, TLS, or TCP. Applies only to connections with IP authentication or FQDN authentication.
        /// </summary>
        [JsonProperty("transport_protocol")]
        public TransportProtocol? TransportProtocol { get; set; } = Entities.Enum.TransportProtocol.UDP;
    }
}
