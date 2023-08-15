namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Feature Detail.
    /// </summary>
    public class MessagingPhoneNumberFeatureDetail
    {
        /// <summary>
        /// Gets or sets a value indicating whether send messages to and receive messages from numbers in the same country.
        /// </summary>
        [JsonProperty("domestic_two_way")]
        public bool DomesticTwoWay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether receive messages from numbers in other countries.
        /// </summary>
        [JsonProperty("international_inbound")]
        public bool InternationalInbound { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether send messages to numbers in other countries.
        /// </summary>
        [JsonProperty("international_outbound")]
        public bool InternationalOutbound { get; set; }
    }
}
