namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class VoiceSettingUpdateOptions : BaseOptions
    {
        /// <summary>
        /// The call forwarding settings for a phone number. Optional.
        /// </summary>
        [JsonProperty("call_forwarding")]
        public CallForwarding CallForwarding { get; set; }

        /// <summary>
        /// The Call Recording Settings for a phone number. Optional.
        /// </summary>
        [JsonProperty("call_recording")]
        public CallRecording CallRecording { get; set; }

        /// <summary>
        /// The cnam listing settings for a phone number. Optional.
        /// </summary>
        [JsonProperty("cnam_listing")]
        public CnamListing CnamListing { get; set; }

        /// <summary>
        ///The media features settings for a phone number.
        /// </summary>
        [JsonProperty("media_features")]
        public MediaFeatures MediaFeatures { get; set; }

        /// <summary>
        /// Controls whether a tech prefix is enabled for this phone number. Default is false.
        /// </summary>
        [JsonProperty("tech_prefix_enabled")]
        public bool TechPrefixEnabled { get; set; }

        /// <summary>
        ///This field allows you to rewrite the destination number of an inbound call before the call is routed to you. 
        ///The value of this field may be any alphanumeric value, and the value will replace the number originally dialed.
        /// </summary>
        [JsonProperty("translated_number")]
        public string TranslatedNumber { get; set; }

        /// <summary>
        /// Controls whether a number is billed per minute or uses your concurrent channels. Default is "pay-per-minute".
        /// </summary>
        /// 
        [JsonProperty("usage_payment_method")]
        public PaymentMethod? UsagePaymentMethod { get; set; } = PaymentMethod.PayPerMinute;
    }
}
