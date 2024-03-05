using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.WireGuardPeers
{
    public class WireGuardPeer : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [JsonProperty("last_seen")]
        public string LastSeen { get; set; }

        [JsonProperty("wireguard_interface_id")]
        public Guid WireGuardInterfaceId { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }
    }
}
