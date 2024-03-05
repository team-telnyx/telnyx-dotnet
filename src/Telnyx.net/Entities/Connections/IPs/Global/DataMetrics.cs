using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class DataMetric
    {
        /// <summary>
        /// The amount of data transmitted or received.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The unit of the amount of data transmitted or received.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
