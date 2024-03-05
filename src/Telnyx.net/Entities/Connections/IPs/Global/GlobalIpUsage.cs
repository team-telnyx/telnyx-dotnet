namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using Newtonsoft.Json;
    using System;
    public class GlobalIpUsage : TelnyxEntity
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("global_ip")]
        public GlobalIp GlobalIp { get; set; }

        [JsonProperty("transmitted")]
        public DataMetric Transmitted { get; set; }

        [JsonProperty("received")]
        public DataMetric Received { get; set; }
    }
   
}
