namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DTMFType
    {
        /// <summary>
        /// Enum RFC2833 for RFC 2833
        /// </summary>
        [EnumMember(Value = "RFC 2833")]
        RFC2833 = 0,

        /// <summary>
        /// Enum Inband for Inband
        /// </summary>
        [EnumMember(Value = "Inband")]
        Inband = 1,

        /// <summary>
        /// Enum SIPINFO for SIP INFO
        /// </summary>
        [EnumMember(Value = "SIP INFO")]
        SIPINFO = 2,
    }
}
