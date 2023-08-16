namespace Telnyx.net.Entities.PhoneNumbers.Searches
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public partial class RegulatoryRequirementPerPhone : TelnyxEntity
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("regulatory_group_id")]
        public Guid RegulatoryGroupId { get; set; }

        [JsonProperty("regulatory_requirements")]
        public List<RegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
