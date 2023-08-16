namespace Telnyx.net.Services.ManagedAccounts
{
    using Newtonsoft.Json;

    public class ManagedAccountListOptions : ListOptions
    {
        /// <summary>
        /// If present, email containing the given value will be returned. Matching is not case-sensitive. Requires at least three characters.
        /// </summary>
        [JsonProperty("filter[email][contains]")]
        public string EmailContains { get; set; }

        /// <summary>
        /// If present, only returns results with the email matching exactly the value given.
        /// </summary>
        [JsonProperty("filter[email][eq]")]
        public string EmailEquals { get; set; }

        /// <summary>
        /// Specifies the sort order for results. By default sorting direction is ascending. To have the results sorted in descending order add the - prefix.
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// Specifies if cancelled accounts should be included in the results.
        /// </summary>
        [JsonProperty("include_cancelled_accounts")]
        public bool IncludeCancelledAccounts { get; set; }
    }
}
