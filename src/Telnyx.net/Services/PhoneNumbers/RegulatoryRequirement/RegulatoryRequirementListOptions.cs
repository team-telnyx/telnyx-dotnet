namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement
{
    using Newtonsoft.Json;
    using static Telnyx.net.Entities.PhoneNumbers.Searches.RegulatoryRequirement;

    public class RegulatoryRequirementListOptions : ListOptions
    {
        /// <summary>
        /// Filter number order regulatory requirements by requirement_id.
        /// </summary>
        [JsonProperty("filter[requirement_id]")]
        public string RequirementId { get; set; }

        /// <summary>
        /// Filter number order regulatory requirements by field_type.
        /// </summary>
        [JsonProperty("filter[field_type]")]
        public FieldTypeEnum? FieldType { get; set; }

        /// <summary>
        /// Filter number order regulatory requirements by requirement_type.
        /// </summary>
        [JsonProperty("filter[requirement_type]")]
        public RequirementTypeEnum? RequirementType { get; set; }
    }
}
