namespace Telnyx.net.Entities.Messaging.MessageMMS
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CreateGroupMMSMessage : BaseOptions
    {
        /// <summary>
        /// Phone number in +E.164 format, used to send the message.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// A list of destination numbers. No more than 8 destinations are allowed.
        /// </summary>
        [JsonProperty("to")]
        public List<string> To { get; set; }

        /// <summary>
        /// Message body (i.e., content) as a non-empty string.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Subject of multimedia message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// A list of media URLs. The total media size must be less than 1 MB.
        /// </summary>
        [JsonProperty("media_urls")]
        public List<string> MediaUrls { get; set; }

        /// <summary>
        /// The URL where webhooks related to this message will be sent.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// The failover URL where webhooks related to this message will be sent if sending to the primary URL fails.
        /// </summary>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// If the profile this number is associated with has webhooks, use them for delivery notifications. 
        /// If webhooks are also specified on the message itself, they will be attempted first, 
        /// then those on the profile.
        /// </summary>
        [JsonProperty("use_profile_webhooks")]
        public bool UseProfileWebhooks { get; set; } = true; // Default value is set to true
    }

}
