using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.ESim.ActionPurchaseEsims
{
    public class UpsertActionPurchaseEsim : BaseOptions
    {
        [JsonProperty("sim_card_group_id")]
        public Guid? SimCardGroupId { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("satus")]
        public string Status { get; set; }
    }
}
