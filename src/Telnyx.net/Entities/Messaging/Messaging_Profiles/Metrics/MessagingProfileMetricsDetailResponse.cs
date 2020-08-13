using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsDetailResponse : TelnyxEntity
    {
        [JsonProperty("data")]
        public MessagingProfileMetricsDetail Data { get; set; }
    }
}
