using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class PercentileLatency
    {
        [JsonProperty("0")]
        public DataMetric Zeroth { get; set; }

        [JsonProperty("25")]
        public DataMetric TwentyFifth { get; set; }

        [JsonProperty("50")]
        public DataMetric Fiftieth { get; set; }

        [JsonProperty("75")]
        public DataMetric SeventyFifth { get; set; }

        [JsonProperty("90")]
        public DataMetric Ninetieth { get; set; }

        [JsonProperty("99")]
        public DataMetric NinetyNinth { get; set; }

        [JsonProperty("100")]
        public DataMetric Hundredth { get; set; }
    }
}
