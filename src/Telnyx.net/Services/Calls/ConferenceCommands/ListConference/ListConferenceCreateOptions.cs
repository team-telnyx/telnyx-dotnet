namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// ListConferenceCreateOptions
    /// </summary>
    public class ListConferenceCreateOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        [JsonProperty("filter[name]")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets pageNumber
        /// </summary>
        [JsonProperty("page[number]")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets pageSize
        /// </summary>
        [JsonProperty("page[size]")]
        public int? PageSize { get; set; }
    }
}
