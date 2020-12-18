using Newtonsoft.Json;

namespace Telnyx.net.Services
{
    public class NumberLookupRecordOptions: BaseOptions
    {
        /// <summary>
        /// Gets or sets type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

    }
}