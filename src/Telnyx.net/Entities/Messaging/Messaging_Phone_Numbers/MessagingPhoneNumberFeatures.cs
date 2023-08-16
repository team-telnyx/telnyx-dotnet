namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Features.
    /// </summary>
    public class MessagingPhoneNumberFeatures
    {
        /// <summary>
        /// Gets or sets the set of features available for a specific messaging use case (SMS or MMS).
        /// </summary>
        [JsonProperty("sms")]
        public MessagingPhoneNumberFeatureDetail Sms { get; set; }

        /// <summary>
        /// Gets or sets the set of features available for a specific messaging use case (SMS or MMS).
        /// </summary>
        [JsonProperty("mms")]
        public MessagingPhoneNumberFeatureDetail Mms { get; set; }
    }
}
