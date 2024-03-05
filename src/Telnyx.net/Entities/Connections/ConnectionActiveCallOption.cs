using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections
{
    public class ConnectionActiveCallOption : ListOptions
    {
        [JsonProperty("limit")]
        public int Limit { get; set; } = 20;

        [JsonProperty("after")]
        public string After { get; set; } = null;

        [JsonProperty("before")]
        public string Before { get; set; } = null;
    }
}
