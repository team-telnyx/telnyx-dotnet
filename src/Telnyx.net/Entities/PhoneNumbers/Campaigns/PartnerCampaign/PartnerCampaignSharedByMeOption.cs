using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign
{
    public class PartnerCampaignSharedByMeOption : ListOptions
    {
        [JsonProperty("page")]
        public int Page { get; set; } 

        [JsonProperty("recordsPerPage")]
        public int RecordsPerPage { get; set; }
    }
}
