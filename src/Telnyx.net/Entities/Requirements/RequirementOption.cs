using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Requirements
{
    public class RequirementOption : ListOptions
    {
        [JsonProperty("filter[country_code]")]
        public string CountryCodeFilter { get; set; }

        [JsonProperty("filter[phone_number_type]")]
        public string PhoneNumberTypeFilter { get; set; }

        [JsonProperty("filter[action]")]
        public string ActionFilter { get; set; }

        [JsonProperty("sort[]")]
        public List<string> Sort { get; set; }
    }
}
