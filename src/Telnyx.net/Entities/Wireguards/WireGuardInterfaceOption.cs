using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces
{
    public class WireGuardInterfaceOption : ListOptions
    {
        [JsonProperty("filter[network_id]")]
        public string NetworkIdFilter { get; set; }
    }
}
