using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsDetail : TelnyxEntity
    {
        [JsonProperty("detialed")]
        public IEnumerable<MessagingProfileMetricsDetailed> Detailed { get; set; }
        
        [JsonProperty("overview")]
        public MessagingProfileMetricsOverview Overview { get; set; }
    }
}
