namespace Telnyx.net.Entities.ManagedAccounts
{
    using Newtonsoft.Json;

    public class ManagedAccount : TelnyxEntity
    {
        /// <summary>
        /// The managed account's V2 API access key.
        /// </summary>
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The managed account's V1 API token.
        /// </summary>
        [JsonProperty("api_token")]
        public string ApiToken { get; set; }

        /// <summary>
        /// The manager account's email, which serves as the V1 API user identifier.
        /// </summary>
        [JsonProperty("api_user")]
        public string ApiUser { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The managed account's email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Uniquely identifies the managed account.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Boolean value that indicates if the managed account is able to have custom pricing set for it or not.
        /// </summary>
        [JsonProperty("managed_account_allow_custom_pricing")]
        public bool ManagedAccountAllowCustomPricing { get; set; }

        /// <summary>
        /// The ID of the manager account associated with the managed account.
        /// </summary>
        [JsonProperty("manager_account_id")]
        public string ManagerAccountId { get; set; }

        /// <summary>
        /// The organization the managed account is associated with.
        /// </summary>
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Boolean value that indicates if the billing information and charges to the managed account "roll up" to the manager account.
        /// </summary>
        [JsonProperty("rollup_billing")]
        public bool RollupBilling { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// object (ManagedAccountBalance).
        /// </summary>
        [JsonProperty("balance")]
        public Balance Balance { get; set; }
    }
}
