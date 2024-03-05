using Newtonsoft.Json;
using System;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class GlobalIpAssignmentUsage : TelnyxEntity
    {
        /// <summary>
        /// The timestamp when the metric was recorded.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The object containing details about the global IP.
        /// </summary>
        [JsonProperty("global_ip")]
        public GlobalIp GlobalIp { get; set; }

        /// <summary>
        /// The object containing details about the global IP assignment.
        /// </summary>
        [JsonProperty("global_ip_assignment")]
        public GlobalIpAssignment GlobalIpAssignment { get; set; }

        /// <summary>
        /// The object containing metrics about the transmitted data.
        /// </summary>
        [JsonProperty("transmitted")]
        public DataMetric Transmitted { get; set; }

        /// <summary>
        /// The object containing metrics about the received data.
        /// </summary>
        [JsonProperty("received")]
        public DataMetric Received { get; set; }
    }

}
