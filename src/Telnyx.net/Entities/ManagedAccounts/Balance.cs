namespace Telnyx.net.Entities.ManagedAccounts
{
    using Newtonsoft.Json;

    public class Balance
    {
        /// <summary>
        /// Available amount to spend (balance + credit limit).
        /// </summary>
        [JsonProperty("available_credit")]
        public decimal AvailableCredit { get; set; }

        /// <summary>
        /// The account's current balance.
        /// </summary>
        [JsonProperty("balance")]
        public decimal AccountBalance { get; set; }

        /// <summary>
        /// The account's credit limit.
        /// </summary>
        [JsonProperty("credit_limit")]
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// The ISO 4217 currency identifier.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
