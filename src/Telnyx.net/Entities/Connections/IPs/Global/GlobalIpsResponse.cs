namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a response containing details of a global IP.
    /// </summary>
    public class GlobalIpsResponse : TelnyxEntity
    {
        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The Global IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// A Global IP ports grouped by protocol code.
        /// </summary>
        [JsonProperty("ports")]
        public PortInfo Ports { get; set; }

        /// <summary>
        /// A user specified name for the address.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A user specified description for the address.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }



}
