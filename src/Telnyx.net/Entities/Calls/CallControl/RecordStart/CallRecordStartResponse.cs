﻿namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// RecordStartResponse.
    /// </summary>
    public class CallRecordStartResponse : TelnyxEntity
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
