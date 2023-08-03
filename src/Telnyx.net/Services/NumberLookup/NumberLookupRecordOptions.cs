namespace Telnyx.net.Services
{
    using Newtonsoft.Json;

    public class NumberLookupRecordOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}