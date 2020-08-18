namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public partial class CreateConferenceResponse : TelnyxEntity
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("expires_at")]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }
    }
}
