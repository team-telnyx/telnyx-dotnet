using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.NumberBlockOrders
{
    public class UpsertNumberBlockOrder : BaseOptions
    {
        [JsonProperty("starting_number")]
        public string StartingNumber { get; set; }

        [JsonProperty("range")]
        public int Range { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }
    }
}
