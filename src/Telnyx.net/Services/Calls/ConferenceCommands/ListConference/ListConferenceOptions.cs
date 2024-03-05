namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// ListConferenceCreateOptions.
    /// </summary>
    public class ListConferenceOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [JsonProperty("filter[name]")]
        public string Name { get; set; }
    }
}
