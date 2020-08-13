using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsDetailed : TelnyxEntity
    {
        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("metrics")]
        public IEnumerable<MessagingProfileMetrics> Metrics { get; set; }
    }
}
