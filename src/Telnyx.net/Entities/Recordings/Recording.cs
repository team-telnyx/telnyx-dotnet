using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Recordings
{
    public class Recording : TelnyxEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("call")]
        public Call Call { get; set; }

        [JsonProperty("download_urls")]
        public DownloadUrls DownloadUrls { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }

    public class Call
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("telnyx_session_uuid")]
        public string TelnyxSessionUuid { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
    }

    public class DownloadUrls
    {
        [JsonProperty("wav")]
        public string Wav { get; set; }
    }
}
