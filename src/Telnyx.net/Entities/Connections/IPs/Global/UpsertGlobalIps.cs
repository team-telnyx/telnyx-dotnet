namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a request to create or update a global IP resource.
    /// </summary>
    public class UpsertGlobalIps : BaseOptions
    {
        /// <summary>
        /// A Global IP ports grouped by protocol code.
        /// </summary>
        [JsonProperty("ports")]
        public PortInfo Ports { get; set; }

        /// <summary>
        /// A user-specified name for the address.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A user-specified description for the address.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }

}
