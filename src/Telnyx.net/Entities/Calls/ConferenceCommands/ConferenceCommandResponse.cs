namespace Telnyx.Net.Entities.Calls.ConferenceCommands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    [ExcludeFromCodeCoverage] // Not referenced anywhere in solution.
    public class ConferenceCommandResponse : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

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
