namespace Telnyx.net.Entities.Faxes
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class Fax : FaxBase
    {
        /// <summary>
        /// ISO 8601 timestamp when resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The URL to the PDF used for the fax's media.
        /// </summary>
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// The quality of the fax.
        /// <para>Options: normal, high, very_high.</para>
        /// </summary>
        [JsonProperty("quality")]
        public string Quality { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType RecordType { get; set; } = RecordType.Fax;

        /// <summary>
        /// Should fax media be stored on temporary URL.
        /// </summary>
        [JsonProperty("store_media")]
        public bool StoreMedia { get; set; }

        /// <summary>
        /// If store_media was set to true, this is a link to temporary location. Link expires after 2h.
        /// </summary>
        [JsonProperty("stored_media_url")]
        public string StoredMediaUrl { get; set; }

        /// <summary>
        /// ISO 8601 timestamp when resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Optional failover URL that will receive fax webhooks if `webhook_url` doesn't return a 2XX response.
        /// </summary>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// URL that will receive fax webhooks.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }
}
