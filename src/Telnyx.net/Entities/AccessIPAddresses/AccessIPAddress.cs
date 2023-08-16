namespace Telnyx.net.Entities.AccessIPAddresses
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.AccessIPAddresses;

    public class AccessIPAddress : TelnyxEntity
    {
        /// <summary>
        /// The ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The description of the resource.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The IP address value.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// The source value.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// The status of the Cloudflare sync.
        /// </summary>
        [JsonProperty("status")]
        public CloudflareSyncStatus Status { get; set; }

        /// <summary>
        /// The ISO 8601 formatted date indicating when the resource was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
