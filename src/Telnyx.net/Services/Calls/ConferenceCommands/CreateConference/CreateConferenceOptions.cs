namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// CreateConferenceOptions.
    /// </summary>
    public class CreateConferenceOptions : BaseOptions
    {
        /// <summary>
        /// The audio file format used when storing the call recording.
        /// </summary>
        /// <value>Can be either mp3 or wav.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum BeepEnum
        {
            /// <summary>
            /// Call Rejected
            /// </summary>
            [EnumMember(Value = "always")]
            ALWAYS = 0,

            /// <summary>
            /// User Busy
            /// </summary>
            [EnumMember(Value = "never")]
            NEVER = 1,

            /// <summary>
            /// 
            /// </summary>
            [EnumMember(Value = "on_enter")]
            ON_ENTER = 2,

            /// <summary>
            /// 
            /// </summary>
            [EnumMember(Value = "on_exit")]
            ON_EXIT = 3,
        }

        /// <summary>
        /// Whether a beep sound should be played when participants join and/or leave the conference.
        /// </summary>
        [JsonProperty("beep_enabled")]
        public BeepEnum? BeepEnabled { get; set; }

        /// <summary>
        /// Time length (minutes) after which the conference will end. Example: 5.
        /// </summary>
        [JsonProperty("duration_minutes")]
        public int DurationMinutes { get; set; }

        /// <summary>
        /// The URL to an audio file to be played to participants joining the conference. Takes effect only when "start_conference_on_create" is set to "false".
        /// Example: "http://www.example.com/audio.wav".
        /// </summary>
        [JsonProperty("hold_audio_url")]
        public string HoldAudioUrl { get; set; }

        /// <summary>
        /// Gets or sets unique identifier and token for controlling the call.
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }

        /// <summary>
        /// Name of the conference.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether the conference should be started on creation. If the conference isn't started all participants that join are automatically put on hold. Defaults to "true".
        /// </summary>
        [JsonProperty("start_conference_on_create")]
        public bool StartConferenceOnCreate { get; set; } = true;
    }
}