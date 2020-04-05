namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Call Dial Response
    /// </summary>
    public class CallDialResponse : TelnyxEntity
    {
        /// <summary>
        /// The status of the Call
        /// </summary>
        /// <value>The status of the call</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RecordTypeEnum
        {
            /// <summary>
            /// Enum PendingEnum for answered
            /// </summary>
            [EnumMember(Value = "call")]
            Call = 0,
        }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordTypeEnum? RecordType { get; set; }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("call_session_id")]
        public Guid? CallSessionId { get; set; }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("call_leg_id")]
        public Guid? CallLegId { get; set; }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("is_alive")]
        public bool IsAlive { get; set; }
    }
}
