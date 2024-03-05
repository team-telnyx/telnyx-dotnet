using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections.IPs.Global
{
    public class GlobalIpAssignment
    {
        /// <summary>
        /// The unique identifier for the Global IP assignment.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier for the Wireguard peer.
        /// </summary>
        [JsonProperty("wireguard_peer_id")]
        public Guid WireguardPeerId { get; set; }

        /// <summary>
        /// The Wireguard peer details.
        /// </summary>
        [JsonProperty("wireguard_peer")]
        public GlobalIp WireguardPeer { get; set; }
    }
}
