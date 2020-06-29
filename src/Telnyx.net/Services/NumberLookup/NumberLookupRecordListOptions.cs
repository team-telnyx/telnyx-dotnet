using Newtonsoft.Json;

namespace Telnyx.net.Services
{
    public class NumberLookupRecordListOptions: ListOptions
    {
        /// <summary>
        /// Gets or sets type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumbers.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}