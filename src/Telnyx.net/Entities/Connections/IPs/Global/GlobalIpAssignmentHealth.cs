using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    /// <summary>
    /// Represents the health information of a global IP assignment.
    /// </summary>
    public class GlobalIpAssignmentHealth : TelnyxEntity
    {
        /// <summary>
        /// The timestamp of the metric.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Information about the global IP.
        /// </summary>
        [JsonProperty("global_ip")]
        public GlobalIp GlobalIp { get; set; }

        /// <summary>
        /// Information about the global IP assignment.
        /// </summary>
        [JsonProperty("global_ip_assignment")]
        public GlobalIpAssignment GlobalIpAssignment { get; set; }

        /// <summary>
        /// Health information.
        /// </summary>
        [JsonProperty("health")]
        public Health Health { get; set; }
    }
}
