using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class Health
    {
        /// <summary>
        /// The number of successful health checks.
        /// </summary>
        [JsonProperty("pass")]
        public int Pass { get; set; }

        /// <summary>
        /// The number of failed health checks.
        /// </summary>
        [JsonProperty("fail")]
        public int Fail { get; set; }
    }
}
