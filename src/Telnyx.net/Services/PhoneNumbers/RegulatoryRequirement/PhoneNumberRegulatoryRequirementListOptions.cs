using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement
{
    public class PhoneNumberRegulatoryRequirementListOptions : ListOptions
    {
        /// <summary>
        /// The list of phone numbers to retrieve regulatory requirements for.
        /// </summary>
        [JsonProperty("filter[phone_number]")]
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
