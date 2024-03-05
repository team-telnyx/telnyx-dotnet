using Newtonsoft.Json;

namespace Telnyx.net.Services.BulkCredentials
{
    public class UpsertBulkCredential : BaseOptions
    {
        [JsonProperty("amount")]
        public string Amount { get; set; } = null;

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null;

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
