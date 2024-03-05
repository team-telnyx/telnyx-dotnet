

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using System;
    using Newtonsoft.Json;

    public class GlobalIpLatencyOptions : BaseOptions
    {
        /// <summary>
        /// Filter by Global IP ID(s) separated by commas.
        /// </summary>
        [JsonProperty("filter[global_ip_id][in]")]
        public string GlobalIpIdIn { get; set; }

        /// <summary>
        /// Filter by timestamp greater than a specific date-time.
        /// </summary>
        [JsonProperty("filter[timestamp][gt]")]
        public DateTime? TimestampGreaterThan { get; set; }

        /// <summary>
        /// Filter by timestamp less than a specific date-time.
        /// </summary>
        [JsonProperty("filter[timestamp][lt]")]
        public DateTime? TimestampLessThan { get; set; }
    }

}
