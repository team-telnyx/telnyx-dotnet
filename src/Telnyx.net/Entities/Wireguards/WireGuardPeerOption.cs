using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.WireGuardPeers
{
    public class WireGuardPeerOption : ListOptions
    {
        [JsonProperty("filter[wireguard_interface_id]")]
        public Guid WireguardInterfaceId { get; set; }
    }
}
