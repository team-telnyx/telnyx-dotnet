using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.OTAUpdates
{
    public class OTAUpdateOption : ListOptions
    {
        [JsonProperty("filter[status]")]
        public string StatusFilter { get; set; }

        [JsonProperty("filter[sim_card_id]")]
        public string SimCardIdFilter { get; set; }

        [JsonProperty("filter[type]")]
        public string TypeFilter { get; set; }
    }
}
