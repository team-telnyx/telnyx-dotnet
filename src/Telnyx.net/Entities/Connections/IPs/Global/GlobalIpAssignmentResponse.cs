namespace Telnyx.net.Entities.Connections.IPs.Global
{
    using Newtonsoft.Json;
    using System;
    public class GlobalIpAssignmentResponse : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("global_ip_id")]
        public Guid GlobalIpId { get; set; }

        [JsonProperty("wireguard_peer_id")]
        public Guid WireguardPeerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_connected")]
        public bool IsConnected { get; set; }

        [JsonProperty("is_in_maintenance")]
        public bool IsInMaintenance { get; set; }

        [JsonProperty("is_announced")]
        public bool IsAnnounced { get; set; }
    }
}
