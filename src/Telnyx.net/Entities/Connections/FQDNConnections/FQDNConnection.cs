using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;

namespace Telnyx.net.Entities.Connections.FQDNConnections
{
    public class FQDNConnection : ConnectionBase
    {
        [JsonProperty("transport_protocol")]
        public TransportProtocol? TransportProtocol { get; set; } = Enum.TransportProtocol.UDP;
    }
}
