using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Networking.Networks
{
    public class NetworkOptions : ListOptions
    {
        /// <summary>
        /// Filter by the name of network.
        /// </summary>
        [JsonProperty("filter[name]")]
        public string Name { get; set; }
    }
}
