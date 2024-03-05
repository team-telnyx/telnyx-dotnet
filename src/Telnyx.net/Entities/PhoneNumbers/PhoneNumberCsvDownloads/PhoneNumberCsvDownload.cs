using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberCsvDownloads
{
    public class PhoneNumberCsvDownload : TelnyxEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
