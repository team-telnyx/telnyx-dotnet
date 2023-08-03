namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    using System;
    using Newtonsoft.Json;

    public class SubNumberOrderListOptions : ListOptions
    {
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }

        [JsonProperty("order_request_id")]
        public Guid OrderRequestId { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("phone_number_type")]
        public string PhoneNumberType { get; set; }

        [JsonProperty("phone_numbers_count")]
        public int PhoneNumbersCount { get; set; }
    }
}
