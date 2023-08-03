namespace Telnyx.net.Entities.PhoneNumbers.SubNumberOrders
{
    using Newtonsoft.Json;

    public class SubNumberOrderRegulatoryRequirement
    {
        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("requirement_id")]
        public string RequirementId { get; set; }
    }
}
