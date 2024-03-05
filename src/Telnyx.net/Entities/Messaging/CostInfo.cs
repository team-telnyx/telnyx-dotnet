using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging
{
    public class CostInfo
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
