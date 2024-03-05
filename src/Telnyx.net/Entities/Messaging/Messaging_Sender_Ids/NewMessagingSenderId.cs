namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// New Messaging Sender Id.
    /// </summary>
    public class NewMessagingSenderId : BaseOptions
    {
        /// <summary>
        /// Gets or sets sending address (+E.164 formatted phone number, alphanumeric sender, or short code).
        /// </summary>
        /// <value>Sending address (+E.164 formatted phone number, alphanumeric sender, or short code).</value>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets receiving address (+E.164 formatted phone number, alphanumeric sender, or short code).
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets Message body (i.e., content) as a non-empty string.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Subject of multimedia message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets Media.
        /// </summary>
        [JsonProperty("media_urls")]
        public List<string> MediaUrls { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this message will be sent.
        /// </summary>
        /// <value>The URL where webhooks related to this message will be sent.</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this message will be sent if sending to the primary URL fails.
        /// </summary>
        /// <value>The failover URL where webhooks related to this message will be sent if sending to the primary URL fails.</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets if the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.
        /// </summary>
        /// <value>If the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.</value>
        [JsonProperty("use_profile_webhooks")]
        public bool? UseProfileWebhooks { get; set; }

        /// <summary>
        /// Automatically detect if an SMS message is unusually long and exceeds a recommended limit of message parts.
        /// </summary>
        [JsonProperty("auto_detect")]
        public bool AutoDetect { get; set; }
    }
}
