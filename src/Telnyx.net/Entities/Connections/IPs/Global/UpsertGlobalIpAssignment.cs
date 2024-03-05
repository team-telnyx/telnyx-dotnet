namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using Newtonsoft.Json;

    public class UpsertGlobalIpAssignment : BaseOptions
    {
        /// <summary>
        /// Flag indicating whether the BGP announcement is enabled or in maintenance mode.
        /// </summary>
        [JsonProperty("is_in_maintenance")]
        public bool IsInMaintenance { get; set; }
    }
}
