namespace Telnyx.net.Services.ManagedAccounts
{
    using Newtonsoft.Json;

    public class CreateManagedAccountOptions : BaseOptions
    {
        /// <summary>
        /// The name of the business for which the new managed account is being created, that will be used as the managed account's organization's name.
        /// </summary>
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        /// <summary>
        /// The email address for the managed account. If not provided, the email address will be generated based on the email address of the manager account.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Boolean value that indicates if the managed account is able to have custom pricing set for it or not. If false, uses the pricing of the manager account. Defaults to false.
        /// </summary>
        [JsonProperty("managed_account_allow_custom_pricing")]
        public bool ManagedAccountAllowCustomPricing { get; set; }

        /// <summary>
        /// Password for the managed account. If a password is not supplied, the account will not be able to be signed into directly. (A password reset may still be performed later to enable sign-in via password.)
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Boolean value that indicates if the billing information and charges to the managed account "roll up" to the manager account. If true, the managed account will not have its own balance and will use the shared balance with the manager account. This value cannot be changed after account creation without going through Telnyx support as changes require manual updates to the account ledger. Defaults to false.
        /// </summary>
        [JsonProperty("rollup_billing")]
        public bool RollupBilling { get; set; }
    }
}
