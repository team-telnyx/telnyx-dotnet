using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    public class Outbound
    {
        [JsonProperty("delivered")]
        public long Delivered { get; set; }

        [JsonProperty("errors")]
        public double Errors { get; set; }

        [JsonProperty("sent")]
        public long Sent { get; set; }
    }
}
