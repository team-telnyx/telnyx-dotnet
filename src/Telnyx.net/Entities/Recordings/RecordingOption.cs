using Newtonsoft.Json;

namespace Telnyx.net.Entities.Recordings
{
    public class RecordingOption : ListOptions
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("telnyx_session_uuid")]
        public string TelnyxSessionUuid { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
    }
}
