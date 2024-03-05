using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    public class SimCardGroupActionOption : ListOptions
    {
        [JsonProperty("filter[sim_card_group_id]")]
        public Guid SimCardGroupId { get; set; }

        [JsonProperty("filter[status]")]
        public string Status { get; set; }

        [JsonProperty("filter[type]")]
        public string ActionType { get; set; }
    }
}
