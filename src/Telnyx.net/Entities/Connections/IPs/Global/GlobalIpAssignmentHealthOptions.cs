namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using System;
    using Newtonsoft.Json;
    public class GlobalIpAssignmentHealthOptions : BaseOptions
    {
        /// <summary>
        /// Filter by Global IP ID(s) separated by commas.
        /// </summary>
        [JsonProperty("filter[global_ip_id][in]")]
        public string GlobalIpIds { get; set; }

        /// <summary>
        /// Filter by Global IP Assignment ID(s) separated by commas.
        /// </summary>
        [JsonProperty("filter[global_ip_assignment_id][in]")]
        public string GlobalIpAssignmentIds { get; set; }

        /// <summary>
        /// Filter by timestamp greater than the specified datetime.
        /// </summary>
        [JsonProperty("filter[timestamp][gt]")]
        public DateTime? TimestampGreaterThan { get; set; }

        /// <summary>
        /// Filter by timestamp less than the specified datetime.
        /// </summary>
        [JsonProperty("filter[timestamp][lt]")]
        public DateTime? TimestampLessThan { get; set; }
    }
}