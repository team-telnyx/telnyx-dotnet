using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    public class SimCardDataUsageNotification : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("sim_card_id")]
        public Guid SimCardId { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("threshold")]
        public Threshold Threshold { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
    public class Threshold
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
