namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// SimCardSearchOptions.
    /// </summary>
    public class BulkSimCardSearchOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets the page number to load.
        /// </summary>
        [JsonProperty("page[number]")]
        public int? PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        [JsonProperty("page[size]")]
        public int? PageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets a bulk SIM card action ID to filter.
        /// </summary>
        [JsonProperty("filter[bulk_sim_card_action_id]")]
        public string BulkSimCardActionId { get; set; }

        /// <summary>
        /// Gets or sets the action type to filter.
        /// </summary>
        [JsonProperty("filter[action_type]")]
        public string ActionType { get; set; }
    }
}
