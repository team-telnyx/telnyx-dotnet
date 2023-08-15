namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MessagingProfileMetricsDetailed : TelnyxEntity
    {
        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("metrics")]
        public IEnumerable<MessagingProfileMetrics> Metrics { get; set; }
    }
}
