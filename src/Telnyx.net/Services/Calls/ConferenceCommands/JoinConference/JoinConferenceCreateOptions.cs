namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JoinConferenceCreateOptions
    /// </summary>
    public class JoinConferenceCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier and token for controlling the call
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id"
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }

        /// <summary>
        /// Whether the conference should end and all remaining participant be hung up after the participant leaves the conference. Defaults to "false".
        /// </summary>
        [JsonProperty("end_conference_on_exit")]
        public bool EndConferenceOnExit { get; set; }

        /// <summary>
        /// Whether the participant should be put on hold immediately after joining the conference. Defaults to "false".
        /// </summary>
        [JsonProperty("hold")]
        public bool Hold { get; set; }

        /// <summary>
        /// The URL of an audio file to be played to the participant when they are put on hold after joining the conference. This property takes effect only if "hold" is set to "true".
        /// </summary>
        [JsonProperty("hold_audio_url")]
        public bool HoldAudioUrl { get; set; }

        /// <summary>
        /// Whether the participant should be muted immediately after joining the conference. Defaults to "false".
        /// </summary>
        [JsonProperty("mute")]
        public bool Mute { get; set; }

        /// <summary>
        /// Whether the conference should be started after the participant joins the conference. Defaults to "false".
        /// </summary>
        [JsonProperty("start_conference_on_enter")]
        public bool StartConferenceOnEnter { get; set; }
    }
}