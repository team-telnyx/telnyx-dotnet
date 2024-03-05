using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PublicInternetGateways
{
    public class PublicInternetGatewayOption : ListOptions
    {
        [JsonProperty("filter[network_id]")]
        public string NetworkIdFilter { get; set; }
    }
}
