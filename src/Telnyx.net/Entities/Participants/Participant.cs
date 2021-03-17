using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Participants
{
    public class Participant : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("end_conference_on_exit")]
        public bool EndConferenceOnExit { get; set; }

        [JsonProperty("soft_end_conference_on_exit")]
        public bool SoftEndConferenceOnExit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("on_hold")]
        public bool OnHold { get; set; }

        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        [JsonProperty("whisper_call_control_ids")]
        public List<string> WhisperCallControlIds { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("call_leg_id")]
        public Guid CallLegId { get; set; }

        [JsonProperty("conference")]
        public ConferenceInfo Conference { get; set; }
    }

    public class ConferenceInfo : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
