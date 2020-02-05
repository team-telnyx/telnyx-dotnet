namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// CostInformation
    /// </summary>
    public class CostInformation
    {
        /// <summary>
        /// Gets or sets UpfrontCost
        /// </summary>
        [JsonProperty("upfront_cost")]
        public string UpfrontCost { get; set; }

        /// <summary>
        /// Gets or sets MonthlyCost
        /// </summary>
        [JsonProperty("monthly_cost")]
        public string MonthlyCost { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 code for the currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
