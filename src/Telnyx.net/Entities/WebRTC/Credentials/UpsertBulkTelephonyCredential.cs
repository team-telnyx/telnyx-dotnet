using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.BulkTelephonyCredentials
{
    public class UpsertBulkTelephonyCredential : BaseOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
    }
}
