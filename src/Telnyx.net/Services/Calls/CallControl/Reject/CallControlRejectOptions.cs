namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlRejectCreateOptions.
    /// </summary>
    public class CallControlRejectOptions : BaseOptions
    {
        /// <summary>
        /// The audio file format used when storing the call recording.
        /// </summary>
        /// <value>Can be either mp3 or wav.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RejectCauseEnum
        {
            /// <summary>
            /// Call Rejected
            /// </summary>
            [EnumMember(Value = "CALL_REJECTED")]
            CALLREJECTED = 0,

            /// <summary>
            /// User Busy
            /// </summary>
            [EnumMember(Value = "USER_BUSY")]
            USERBUSY = 1,
        }

        /// <summary>
        /// Cause for call rejection.
        /// </summary>
        [JsonProperty("cause")]
        public RejectCauseEnum? Cause { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }
    }
}