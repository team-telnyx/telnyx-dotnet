using Newtonsoft.Json;

namespace Telnyx
{
    /// <summary>
    /// ChannelZoneUpdate for updating the quantity of reserved channels.
    /// </summary>
    public class ChannelZoneUpdate : BaseOptions
    {
        /// <summary>
        /// Gets or sets the quantity of reserved channels.
        /// </summary>
        [JsonProperty("channels")]
        public long Channels { get; set; }
    }
}
