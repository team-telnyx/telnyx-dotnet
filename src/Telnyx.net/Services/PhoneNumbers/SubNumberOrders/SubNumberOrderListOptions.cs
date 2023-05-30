using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
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
