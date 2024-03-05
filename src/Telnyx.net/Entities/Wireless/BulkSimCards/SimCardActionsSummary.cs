using Newtonsoft.Json;
namespace Telnyx
{
    public class SimCardActionsSummary
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}
