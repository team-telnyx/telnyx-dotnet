using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    public class UpsertSIMCardDataUsageNotification : BaseOptions
    {
        [JsonProperty("sim_card_id")]
        public Guid SimCardId { get; set; }

        [JsonProperty("threshold")]
        public DataUsageThreshold Threshold { get; set; }
    }
    public class DataUsageThreshold
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
