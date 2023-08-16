namespace Telnyx
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// GatherUsingSpeak Response.
    /// </summary>
    public class CallGatherUsingSpeakResponse : TelnyxEntity
    {
        /// <summary>
        /// The status of the Call.
        /// </summary>
        /// <value> Status of the Call.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ResultEnum
        {
            /// <summary>
            /// Enum PendingEnum for answered
            /// </summary>
            [EnumMember(Value = "ok")]
            Success = 0,
        }

        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("result")]
        public ResultEnum? Result { get; set; }
    }
}
