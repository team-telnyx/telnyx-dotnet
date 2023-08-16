namespace Telnyx.net.Services.Faxes.Applications
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Applications;
    using Telnyx.net.Entities.Enum;

    public class FaxAppOptions : BaseOptions
    {
        /// <summary>
        /// Specifies whether the connection can be used.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// `Latency` directs Telnyx to route media through the site with the lowest round-trip time to the user's connection. Telnyx calculates this time using ICMP ping messages. This can be disabled by specifying a site to handle all media.
        /// </summary>
        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride AnchorsiteOverride { get; set; } = AnchorsiteOverride.Latency;

        /// <summary>
        /// A user-assigned name to help manage the application.
        /// </summary>
        [JsonRequired]
        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        /// <summary>
        /// The failover URL where webhooks related to this connection will be sent if sending to the primary URL fails. Must include a scheme, such as 'https'.
        /// </summary>
        [JsonProperty("webhook_event_failover_url")]
        public string WebhookEventFailoverUrl { get; set; } = string.Empty;

        /// <summary>
        /// The URL where webhooks related to this connection will be sent.Must include a scheme, such as 'https'.
        /// </summary>
        [JsonRequired]
        [JsonProperty("webhook_event_url")]
        public string WebhookEventUrl { get; set; }

        /// <summary>
        /// Specifies how many seconds to wait before timing out a webhook.
        /// </summary>
        [JsonProperty("webhook_timeout_secs")]
        public int? WebhookTimeoutSecs { get; set; } = null;
    }
}
