namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Phone number
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets recordType
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets _PhoneNumber
        /// </summary>
        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }

        /// <summary>
        /// Gets or sets regulatoryGroupId
        /// </summary>
        [JsonProperty("regulatory_group_id")]
        public string RegulatoryGroupId { get; set; }

        /// <summary>
        /// Gets or sets RegulatoryRequirements
        /// </summary>
        [JsonProperty("regulatory_requirements")]
        public List<PhoneNumberRegulatoryRequirement> RegulatoryRequirements { get; set; }

        /// <summary>
        /// Gets or sets value true if all requirements are met for a phone number, false otherwise
        /// </summary>
        [JsonProperty("requirements_met")]
        public bool? RequirementsMet { get; set; }
    }
}
