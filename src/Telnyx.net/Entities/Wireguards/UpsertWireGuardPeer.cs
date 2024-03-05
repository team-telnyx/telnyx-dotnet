using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.WireGuardPeers
{
    public class UpsertWireGuardPeer : BaseOptions
    {
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [JsonProperty("wireguard_interface_id")]
        public Guid WireGuardInterfaceId { get; set; }
    }
}
