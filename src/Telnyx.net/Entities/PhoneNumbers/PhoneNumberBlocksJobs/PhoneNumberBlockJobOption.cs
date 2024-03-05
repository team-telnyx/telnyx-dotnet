using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs
{
    public class PhoneNumberBlocksJobOption : ListOptions
    {
        [JsonProperty("filter[type]")]
        public string Type { get; set; }

        [JsonProperty("filter[status]")]
        public string Status { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }
    }
}
