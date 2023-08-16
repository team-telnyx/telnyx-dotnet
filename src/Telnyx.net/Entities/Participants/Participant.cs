namespace Telnyx.net.Entities.Participants
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class Participant : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// ISO 8601 formatted date of when the participant was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// ISO 8601 formatted date of when the participant was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// "Whether the conference will end and all remaining participants be hung up after the participant leaves the conference.
        /// </summary>
        [JsonProperty("end_conference_on_exit")]
        public bool EndConferenceOnExit { get; set; }

        /// <summary>
        /// Whether the conference will end after the participant leaves the conference.
        /// </summary>
        [JsonProperty("soft_end_conference_on_exit")]
        public bool SoftEndConferenceOnExit { get; set; }

        /// <summary>
        /// The status of the participant with respect to the lifecycle within the conference.
        /// <para>Types are: ["joining","joined","left"]. </para>
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Whether the participant is muted.
        /// </summary>
        [JsonProperty("muted")]
        public bool Muted { get; set; }

        /// <summary>
        /// Whether the participant is put on_hold.
        /// </summary>
        [JsonProperty("on_hold")]
        public bool OnHold { get; set; }

        /// <summary>
        /// Call Control ID associated with the partiipant of the conference.
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Array of unique call_control_ids the participant can whisper to.
        /// </summary>
        [JsonProperty("whisper_call_control_ids")]
        public List<string> WhisperCallControlIds { get; set; }

        /// <summary>
        /// Uniquely identifies the participant.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Uniquely identifies the call leg associated with the participant.
        /// </summary>
        [JsonProperty("call_leg_id")]
        public Guid CallLegId { get; set; }

        /// <summary>
        /// Info about the conference that the participant is in.
        /// </summary>
        [JsonProperty("conference")]
        public ConferenceInfo Conference { get; set; }
    }

    public class ConferenceInfo : TelnyxEntity
    {
        /// <summary>
        /// Uniquely identifies the conference.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the conference.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
