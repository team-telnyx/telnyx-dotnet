namespace Telnyx.net.Entities.AccessIPRanges
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.AccessIPRanges;

    public class AccessIPRanges : TelnyxEntity
    {
        /// <summary>
        /// The CIDR block.
        /// </summary>
        [JsonProperty("cidr_block")]
        public string CidrBlock { get; set; }

        /// <summary>
        /// The created date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status.
        /// </summary>
        [JsonProperty("status")]
        public CloudflareSyncStatus Status { get; set; }

        /// <summary>
        /// The updated date.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The user ID.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
