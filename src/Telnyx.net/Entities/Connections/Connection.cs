namespace Telnyx.net.Entities.Connections
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Infrastructure.JsonConverters;

    public class Connection : TelnyxEntity
    {
        /// <summary>
        /// Defaults to true.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; } = true;

        /// <summary>
        /// `Latency` directs Telnyx to route media through the site with the lowest round-trip time to the user's connection. Telnyx calculates this time using ICMP ping messages. This can be disabled by specifying a site to handle all media.
        /// </summary>
        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride? AnchorsiteOverride { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("webhook_api_version")]
        public WebhookAPIVersion? WebhookApiVersion { get; set; }

        [JsonProperty("webhook_event_failover_url")]
        public string WebhookEventFailoverUrl { get; set; }

        [JsonProperty("webhook_event_url")]
        public string WebhookEventUrl { get; set; }
    }
}
