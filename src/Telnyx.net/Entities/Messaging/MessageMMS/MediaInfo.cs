using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging.MessageMMS
{
    public class MediaInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }

        [JsonProperty("size")]
        public int? Size { get; set; } // Nullable as it can be null according to the information
    }
}
