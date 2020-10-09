namespace Telnyx
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Payload.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Payload
    {
        /// <summary>
        /// The status of the Call.
        /// </summary>
        /// <value>Status of the call.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StateEnum
        {
            /// <summary>
            /// Enum PendingEnum for answered
            /// </summary>
            [EnumMember(Value = "answered")]
            AnsweredEnum = 0,

            /// <summary>
            /// Enum PendingEnum for bridged
            /// </summary>
            [EnumMember(Value = "bridged")]
            BridgedEnum = 1
        }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets an ISO 8901 datetime string denoting when the event occured.
        /// </summary>
        /// <value>An ISO 8901 datetime string denoting when the number order was created.</value>
        [JsonProperty("occurred_at")]
        public string OccurredAt { get; set; }

        /// <summary>
        /// Gets or sets number or SIP user placing the call.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets call id used to issue commands via call control API.
        /// </summary>
        [JsonProperty("call_control_id")]
        public Guid? CallControlId { get; set; }

        /// <summary>
        /// Gets or sets telnyx connection id used in the call.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets iD that is unique to the call and can be used to correlate webhook events.
        /// </summary>
        [JsonProperty("call_leg_id")]
        public string CallLegId { get; set; }

        /// <summary>
        /// Gets or sets iD that is unique to the call and can be used to correlate webhook events.
        /// </summary>
        [JsonProperty("call_session_id")]
        public string CallSessionId { get; set; }

        /// <summary>
        /// Gets or sets state received from a command.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets state received from a command.
        /// </summary>
        [JsonProperty("state")]
        public StateEnum? State { get; set; }
    }
}
