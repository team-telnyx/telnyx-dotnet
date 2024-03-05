using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class GlobalIp
    {
        /// <summary>
        /// The unique identifier for the Global IP.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The Global IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}
