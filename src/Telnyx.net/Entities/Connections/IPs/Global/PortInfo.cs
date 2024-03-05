using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    /// <summary>
    /// Represents the ports associated with a global IP, grouped by protocol.
    /// </summary>
    public class PortInfo
    {
        /// <summary>
        /// TCP ports.
        /// </summary>
        [JsonProperty("tcp")]
        public List<int> Tcp { get; set; }

        /// <summary>
        /// UDP ports.
        /// </summary>
        [JsonProperty("udp")]
        public List<int> Udp { get; set; }
    }
}
