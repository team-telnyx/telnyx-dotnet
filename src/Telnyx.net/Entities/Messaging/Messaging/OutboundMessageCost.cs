namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Outbound message cost
    /// </summary>
    public class OutboundMessageCost
    {
        /// <summary>
        /// Gets or sets the amount deducted from your account.
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 currency identifier.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
