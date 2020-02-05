namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// NewMessage
    /// </summary>
    public class NewMessage : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets sending address (+E.164 formatted phone number, alphanumeric sender, or short code)
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets To
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets message body (i.e., content) as a non-empty string
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a list of media URLs. The total media size must be less than 1 MB.
        /// </summary>
        [JsonProperty("media_urls")]
        public List<string> MediaUrls { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this message will be sent.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this message will be sent if sending to the primary URL fails.
        /// </summary>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets if the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.
        /// </summary>
        [JsonProperty("use_profile_webhooks")]
        public bool? UseProfileWebhooks { get; set; }

        /// <summary>
        /// Gets or sets if the message is not pulled off the queue and sending attempted within this amount of time, sending will be aborted and the message will be marked as expired.
        /// </summary>
        [JsonProperty("validity_period_secs")]
        public decimal? ValidityPeriodSecs { get; set; }

        /// <summary>
        /// Gets or sets typically, if the LRN dip indicates that the phone number is a land-line, the request will be rejected. However, some landlines can receive SMS, so that behavior can be overridden by setting this value to &#x60;true&#x60;
        /// </summary>
        [JsonProperty("ignore_wire_type")]
        public bool? IgnoreWireType { get; set; }
    }
}