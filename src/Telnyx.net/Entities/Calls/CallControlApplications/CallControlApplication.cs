namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class CallControlApplication : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        /// <value>Identifies the type of the resource.</value>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or Sets ApplicationName.
        /// </summary>
        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or Sets Active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets AnchorsiteOverride.
        /// </summary>
        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride? AnchorsiteOverride { get; set; }

        /// <summary>
        /// Gets or Sets DtmfType.
        /// </summary>
        [JsonProperty("dtmf_type")]
        public DTMFType? DtmfType { get; set; }

        /// <summary>
        /// Gets or Sets WebhookEventUrl.
        /// </summary>
        [JsonProperty("webhook_event_url")]
        public string WebhookEventUrl { get; set; }

        /// <summary>
        /// Gets or Sets WebhookEventFailoverUrl.
        /// </summary>
        [JsonProperty("webhook_event_failover_url")]
        public string WebhookEventFailoverUrl { get; set; }

        /// <summary>
        /// Gets or Sets WebhookApiVersion.
        /// </summary>
        [JsonProperty("webhook_api_version")]
        public WebhookAPIVersion? WebhookApiVersion { get; set; }

        /// <summary>
        /// Gets or Sets FirstCommandTimeout.
        /// </summary>
        [JsonProperty("first_command_timeout")]
        public bool FirstCommandTimeout { get; set; }

        /// <summary>
        /// Gets or Sets FirstCommandTimeoutSecs.
        /// </summary>
        [JsonProperty("first_command_timeout_secs")]
        public int FirstCommandTimeoutSecs { get; set; }

        /// <summary>
        /// Gets or Sets WebhookTimeoutSecs.
        /// </summary>
        [JsonProperty("webhook_timeout_secs")]
        public int WebhookTimeoutSecs { get; set; }

        /// <summary>
        /// Gets or Sets Inbound.
        /// </summary>
        [JsonProperty("inbound")]
        public CallControlApplicationInbound Inbound { get; set; }

        /// <summary>
        /// Gets or Sets Outbound.
        /// </summary>
        [JsonProperty("outbound")]
        public CallControlApplicationOutbound Outbound { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
