namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class NumberConfigurationsListOptions : ListOptions
    {
        /// <summary>
        /// Filter by phone number status. Example: "active".
        /// </summary>
        [JsonProperty("filter[status]")]
        public NumberConfigStatus? Status { get; set; }

        /// <summary>
        /// Filter starts with connection name. Requires at least three characters.
        /// </summary>
        [JsonProperty("filter[voice.connection_name][starts_with]")]
        public string ConnectionNameStartWith { get; set; }

        /// <summary>
        /// Filter ends with connection name. Requires at least three characters.
        /// </summary>
        [JsonProperty("filter[voice.connection_name][ends_with]")]
        public string ConnectionNameEndsWith { get; set; }

        /// <summary>
        /// Filter by connection name.
        /// </summary>
        [JsonProperty("filter[voice.connection_name][eq]")]
        public string ConnectionNameEquals { get; set; }

        /// <summary>
        /// Filter contains connection name. Requires at least three characters.
        /// </summary>
        [JsonProperty("filter[voice.connection_name][contains]")]
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

        /// <summary>
        /// Filter by phone number tags.
        /// </summary>
        /// 
        [JsonProperty("filter[tag]")]
        public string Tag { get; set; }
    }
}
