namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MessagingProfileMetricsDetail : TelnyxEntity
    {
        [JsonProperty("detailed")]
        public IEnumerable<MessagingProfileMetricsDetailed> Detailed { get; set; }

        [JsonProperty("overview")]
        public MessagingProfileMetricsOverview Overview { get; set; }
    }
}
