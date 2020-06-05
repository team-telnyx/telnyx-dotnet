using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Connections.IPs
{
    public class IPListOptions : ListOptions
    {
        /// <summary>
        /// ID of the IPConnection to which this IP should be attached.
        /// </summary>
        [JsonProperty("filter[connection_id]")]
        public string ConnectionId { get; set; } = null;
        /// <summary>
        /// IP adddress represented by this resource.
        /// </summary>
        [JsonProperty("filter[ip_address]")]
        public string IPAddress { get; set; }
        /// <summary>
        /// Port to use when connecting to this IP. Example: 5060
        /// </summary>
        [JsonProperty("filter[port]")]
        public int? Port { get; set; }
    }
}
