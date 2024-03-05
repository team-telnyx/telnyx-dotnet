using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.NumberBlockOrders
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Represents the query parameters for filtering and paging through number block orders.
    /// </summary>
    public class NumberBlockOrderOptions : ListOptions
    {
        [JsonProperty("filter[status]")]
        public string Status { get; set; }

        [JsonProperty("filter[created_at][gt]")]
        public string CreatedAfter { get; set; }

        [JsonProperty("filter[created_at][lt]")]
        public string CreatedBefore { get; set; }

        [JsonProperty("filter[phone_numbers.starting_number]")]
        public string StartingPhoneNumber { get; set; }

    }
}
