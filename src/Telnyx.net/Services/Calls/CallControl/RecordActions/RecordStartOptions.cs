namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public class RecordStartOptions : RecordActionOptions
    {
        /// <summary>
        /// The audio file format used when storing the call recording.
        /// </summary>
        /// <value>Can be either mp3 or wav.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum FormatEnum
        {
            /// <summary>
            /// Enum PendingEnum for answered
            /// </summary>
            [EnumMember(Value = "wav")]
            WavEnum = 0,

            /// <summary>
            /// Enum PendingEnum for bridged
            /// </summary>
            [EnumMember(Value = "mp3")]
            Mp3Enum = 1,
        }

        /// <summary>
        /// When dual, final audio file will be stereo recorded with the first leg on channel A, and the rest on channel B.
        /// </summary>
        /// <value>dual or single.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ChannelEnum
        {
            /// <summary>
            /// Enum PendingEnum for answered
            /// </summary>
            [EnumMember(Value = "single")]
            SingleEnum = 0,

            /// <summary>
            /// Enum PendingEnum for bridged
            /// </summary>
            [EnumMember(Value = "dual")]
            DualEnum = 1,
        }

        /// <summary>
        /// When `dual`, final audio file will be stereo recorded with the first leg on channel A, and the rest on channel B.
        /// <para>Example: "dual".</para>
        /// <para>Options: ["single", "dual"].</para>
        /// </summary>
        [JsonProperty("channels")]
        public ChannelEnum? Channels { get; set; }

        /// <summary>
        /// The audio file format used when storing the call recording. Can be either `mp3` or `wav`.
        /// <para>Example: "mp3".</para>
        /// <para>Options: ["mp3", "wav"].</para>
        /// </summary>
        [JsonProperty("format")]
        public FormatEnum? Format { get; set; }

        /// <summary>
        /// If enabled, a beep sound will be played at the start of a recording.
        /// </summary>
        [JsonProperty("play_beep")]
        public bool PlayBeep { get; set; }
    }
}
