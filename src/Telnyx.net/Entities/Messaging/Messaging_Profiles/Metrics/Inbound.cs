using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{

    public class Inbound
    {
        [JsonProperty("received")]
        public long Received { get; set; }
    }
}
