namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PhoneNumberRegulatoryRequirementListOptions : ListOptions
    {
        /// <summary>
        /// The list of phone numbers to retrieve regulatory requirements for.
        /// </summary>
        [JsonProperty("filter[phone_number]")]
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
