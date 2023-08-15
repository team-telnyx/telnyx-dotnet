namespace Telnyx.net.Services.Calls.ConferenceCommands.Participants
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DialParticipantOptions : BaseOptions
    {
        /// <summary>
        /// Unique identifier and token for controlling the call.
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Use this field to avoid execution of duplicate commands. Telnyx will ignore subsequent commands with the same `command_id` as one that has already been executed.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }

        /// <summary>
        /// Whether the participant should be put on hold immediately after joining the conference.
        /// </summary>
        [JsonProperty("hold")]
        public bool Hold { get; set; }

        /// <summary>
        /// The URL of an audio file to be played to the participant when they are put on hold after joining the conference. This property takes effect only if "hold" is set to "true".
        /// </summary>
        [JsonProperty("hold_audio_url")]
        public string HoldAudioUrl { get; set; }

        /// <summary>
        /// Whether the participant should be muted immediately after joining the conference.
        /// </summary>
        [JsonProperty("mute")]
        public bool Mute { get; set; }

        /// <summary>
        /// The `from` number to be used as the caller id presented to the destination (`to` number).
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// The DID or SIP URI to dial out and bridge to the given call.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Whether the conference should be started after the participant joins the conference.
        /// </summary>
        [JsonProperty("start_conference_on_enter")]
        public bool StartConferenceOnEnter { get; set; }

        /// <summary>
        /// Sets the joining participant as a supervisor for the conference. A conference can have multiple supervisors. "barge" means the supervisor enters the conference as a normal participant. This is the same as "none". "monitor" means the supervisor is muted but can hear all participants. "whisper" means that only the specified "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
        /// </summary>
        [JsonProperty("supervisor_role")]
        public string SupervisorRole { get; set; }

        /// <summary>
        /// Array of unique call_control_ids the joining supervisor can whisper to. If none provided, the supervisor will join the conference as a monitoring participant only.
        /// </summary>
        [JsonProperty("whisper_call_control_ids")]
        public List<string> WhisperCallControlIds { get; set; }
    }
}
