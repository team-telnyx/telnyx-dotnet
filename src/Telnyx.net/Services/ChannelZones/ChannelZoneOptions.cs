using Newtonsoft.Json;

namespace Telnyx
{
    /// <summary>
    /// ChannelZoneOptions for pagination.
    /// </summary>
    public class ChannelZoneOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the page number to load.
        /// </summary>
        [JsonProperty("page[number]")]
        public int PageNumber { get; set; } = 1; // Default value

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        [JsonProperty("page[size]")]
        public int PageSize { get; set; } = 20; // Default value
    }
}
