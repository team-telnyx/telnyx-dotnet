namespace Telnyx.net.Entities.PhoneNumbers.SubNumberOrders
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SubNumberOrder : TelnyxEntity
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("order_request_id")]
        public string OrderRequestId { get; set; }

        [JsonProperty("phone_number_type")]
        public string PhoneNumberType { get; set; }

        [JsonProperty("phone_numbers_count")]
        public int PhoneNumbersCount { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("regulatory_requirements")]
        public List<SubNumberOrderRegulatoryRequirement> RegulatoryRequirements { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
