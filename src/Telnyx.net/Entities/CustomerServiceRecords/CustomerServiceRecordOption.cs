using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CustomerServiceRecords
{
    public class CustomerServiceRecordOption : ListOptions
    {
        [JsonProperty("sort[]")]
        public string[] Sort { get; set; }

        [JsonProperty("phone_number[eq]")]
        public string PhoneNumberEqual { get; set; }

        [JsonProperty("phone_number[in][]")]
        public string[] PhoneNumberIn { get; set; }

        [JsonProperty("status[eq]")]
        public string StatusEqual { get; set; }

        [JsonProperty("status[in][]")]
        public string[] StatusIn { get; set; }

        [JsonProperty("created_at[lt]")]
        public DateTime? CreatedAtLessThan { get; set; }

        [JsonProperty("created_at[gt]")]
        public DateTime? CreatedAtGreaterThan { get; set; }
    }
}
