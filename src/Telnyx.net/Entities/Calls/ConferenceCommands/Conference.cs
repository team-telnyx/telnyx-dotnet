namespace Telnyx.net.Entities.Calls.ConferenceCommands
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class Conference : TelnyxEntity
    {
        [JsonProperty("connection_id")]
        public Guid ConnectionId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("end_reason")]
        public string EndReason { get; set; }

        [JsonProperty("ended_by")]
        public EndedBy EndedBy { get; set; }

        [JsonProperty("expires_at")]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class EndedBy
    {
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        [JsonProperty("call_session_id")]
        public Guid CallSessionId { get; set; }
    }
}
