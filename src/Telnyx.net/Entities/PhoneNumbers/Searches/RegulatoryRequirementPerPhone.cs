namespace Telnyx.net.Entities.PhoneNumbers.Searches
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public partial class RegulatoryRequirementPerPhone : TelnyxEntity
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("regulatory_group_id")]
        public Guid RegulatoryGroupId { get; set; }

        [JsonProperty("regulatory_requirements")]
        public List<RegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
