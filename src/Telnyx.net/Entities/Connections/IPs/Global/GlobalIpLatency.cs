using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class GlobalIpLatency : TelnyxEntity
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("global_ip")]
        public GlobalIp GlobalIp { get; set; }

        [JsonProperty("prober_location")]
        public ProberLocation ProberLocation { get; set; }

        [JsonProperty("mean_latency")]
        public DataMetric MeanLatency { get; set; }

        [JsonProperty("percentile_latency")]
        public PercentileLatency PercentileLatency { get; set; }
    }

}
