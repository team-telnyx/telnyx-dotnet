namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DTMFType
    {
        [EnumMember(Value = "RFC 2833")]
        RFC_2833 = 0,
        [EnumMember(Value = "Inband")]
        Inband = 1,
        [EnumMember(Value = "SIP INFO")]
        SIP_Info = 2
    }
}
