using Newtonsoft.Json;

namespace Telnyx.net.Entities.CustomStorageCredentials
{
    public class CustomStorageCredential : TelnyxEntity
    {

        [JsonProperty("backend")]
        public string Backend { get; set; }

        [JsonProperty("configuration")]
        public StorageConfiguration Configuration { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
