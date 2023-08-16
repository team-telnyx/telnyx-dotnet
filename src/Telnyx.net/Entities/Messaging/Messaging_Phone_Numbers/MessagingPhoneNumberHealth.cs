namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// High level health metrics for the number and its messaging sending patterns.
    /// </summary>
    public class MessagingPhoneNumberHealth
    {
        /// <summary>
        /// Gets or sets the number of messages analyzed for the health metrics.
        /// </summary>
        [JsonProperty("message_count")]
        public long MessageCount { get; set; }

        /// <summary>
        /// Gets or sets the ratio of messages received to the number of messages sent.
        /// </summary>
        [JsonProperty("inbound_outbound_ratio")]
        public float InboundOutboundRatio { get; set; }

        /// <summary>
        /// Gets or sets the ratio of messages sucessfully delivered to the number of messages attempted.
        /// </summary>
        [JsonProperty("success_ratio")]
        public float SuccessRatio { get; set; }

        /// <summary>
        /// Gets or sets the ratio of messages blocked for spam to the number of messages attempted.
        /// </summary>
        [JsonProperty("spam_ratio")]
        public double SpamRatio { get; set; }
    }
}
