using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs
{
    public class SettingSIMCardPublicIP : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("sim_card_id")]
        public Guid SIMCardId { get; set; }

        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        [JsonProperty("status")]
        public SIMCardActionStatus Status { get; set; }

        [JsonProperty("settings")]
        public string Settings { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class SIMCardActionStatus
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
