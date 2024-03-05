using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.WDRReports
{
    public class ReportWdrOption : ListOptions
    {
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        [JsonProperty("mnc")]
        public string Mnc { get; set; }

        [JsonProperty("imsi")]
        public string Imsi { get; set; }

        [JsonProperty("sim_group_name")]
        public string SimGroupName { get; set; }

        [JsonProperty("sim_group_id")]
        public string SimGroupId { get; set; }

        [JsonProperty("sim_card_id")]
        public string SimCardId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("sort")]
        public string[] Sort { get; set; }
    }
}
