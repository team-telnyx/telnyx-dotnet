using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging
{
    public class MessageParticipant
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("line_type")]
        public string LineType { get; set; }
    }
}
