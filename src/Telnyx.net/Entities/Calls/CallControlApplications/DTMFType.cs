namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    /// <value>Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF digits sent to Telnyx will be accepted in all formats.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DTMFType
    {
        /// <summary>
        /// Enum RFC2833Enum for RFC 2833
        /// </summary>
        [EnumMember(Value = "RFC 2833")]
        RFC2833Enum = 0,

        /// <summary>
        /// Enum InbandEnum for Inband
        /// </summary>
        [EnumMember(Value = "Inband")]
        InbandEnum = 1,

        /// <summary>
        /// Enum SIPINFOEnum for SIP INFO
        /// </summary>
        [EnumMember(Value = "SIP INFO")]
        SIPINFOEnum = 2,
    }
}
