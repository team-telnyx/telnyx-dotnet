namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class VoiceSettingsListOptions : ListOptions
    {
        /// <summary>
        /// Filter contains connection name. Requires at least three characters.
        /// </summary>
        [JsonProperty("filter[connection_name][contains]")]
        public string ConnectionNameContains { get; set; }

        /// <summary>
        ///Filter by usage_payment_method.
        /// </summary>
        [JsonProperty("filter[usage_payment_method]")]
        public PaymentMethod? UsagePaymentMethod { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order.
        /// </summary>
        [JsonProperty("sort")]
        public Sort? Sort { get; set; }

        /// <summary>
        /// Filter by phone number. Requires at least three digits. 
        /// Non-numerical characters will result in no values being returned.
        /// </summary>
        /// 
        [JsonProperty("filter[phone_number]")]
        public string PhoneNumber { get; set; }
    }
}
