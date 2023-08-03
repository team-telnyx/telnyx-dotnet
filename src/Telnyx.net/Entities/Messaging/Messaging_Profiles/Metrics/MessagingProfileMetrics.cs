namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using Newtonsoft.Json;

    public class MessagingProfileMetrics : TelnyxEntity
    {
        /// <summary>
        /// The number of outbound messages successfully delivered.
        /// </summary>
        [JsonProperty("delivered")]
        public long Delivered { get; set; }

        /// <summary>
        /// The ratio of outbound messages sent that resulted in errors.
        /// </summary>
        [JsonProperty("errors")]
        public double Errors { get; set; }

        /// <summary>
        /// The metric type.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The number of inbound messages received.
        /// </summary>
        [JsonProperty("received")]
        public long Received { get; set; }

        /// <summary>
        /// The number of outbound messages sent.
        /// </summary>
        [JsonProperty("sent")]
        public long Sent { get; set; }
    }
}
