namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for call control record start create options
    /// </summary>
    public class CallControlRecordStartCreateOptions : BaseOptions
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
            Mp3Enum = 1
        }

        /// <summary>
        /// When dual, final audio file will be stereo recorded with the first leg on channel A, and the rest on channel B.
        /// </summary>
        /// <value>dual or single</value>
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
            DualEnum = 1
        }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("format")]
        public FormatEnum? Format { get; set; }

        /// <summary>
        /// Gets or sets field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("channels")]
        public ChannelEnum? Channel { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a beep sound will be played at the start of a recording.
        /// </summary>
        [JsonProperty("play_beep")]
        public bool PlayBeep { get; set; }
    }
}