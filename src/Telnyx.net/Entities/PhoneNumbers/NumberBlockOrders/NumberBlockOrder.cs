using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.NumberBlockOrders
{
    public class NumberBlockOrder : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("starting_number")]
        public string StartingNumber { get; set; }

        [JsonProperty("range")]
        public int Range { get; set; }

        [JsonProperty("phone_numbers_count")]
        public int PhoneNumbersCount { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("requirements_met")]
        public bool RequirementsMet { get; set; }
    }
}
