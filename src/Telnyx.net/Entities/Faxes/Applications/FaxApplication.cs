namespace Telnyx.net.Entities.Faxes.Applications
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Applications;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    ///  Fax Applications are used to configure how you send and receive faxes using the Programmable Fax API with Telnyx.
    /// </summary>
    public class FaxApplication : TelnyxEntity
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
        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType RecordType { get; set; } = RecordType.FaxApplication;

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// The failover URL where webhooks related to this connection will be sent if sending to the primary URL fails. Must include a scheme, such as 'https'.
        /// </summary>
        [JsonProperty("webhook_event_failover_url")]
        public string WebhookEventFailoverUrl { get; set; } = string.Empty;

        /// <summary>
        /// The URL where webhooks related to this connection will be sent.Must include a scheme, such as 'https'.
        /// </summary>
        [JsonProperty("webhook_event_url")]
        public string WebhookEventUrl { get; set; }

        /// <summary>
        /// Specifies how many seconds to wait before timing out a webhook.
        /// </summary>
        [JsonProperty("webhook_timeout_secs")]
        public int? WebhookTimeoutSecs { get; set; } = null;
    }
}
