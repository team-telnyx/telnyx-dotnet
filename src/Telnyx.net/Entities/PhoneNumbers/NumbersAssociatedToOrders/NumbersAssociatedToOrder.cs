namespace Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.PhoneNumbers.NumbersAssociatedToOrders;

    public class NumbersAssociatedToOrder : TelnyxEntity
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("order_request_id")]
        public string OrderRequestId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("phone_number_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhoneNumberType PhoneNumberType { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("regulatory_requirements")]
        public List<PhoneNumberRegulatoryRequirement> RegulatoryRequirements { get; set; }

        [JsonProperty("requirements_met")]
        public bool RequirementsMet { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sub_number_order_id")]
        public string SubNumberOrderId { get; set; }
    }
}
