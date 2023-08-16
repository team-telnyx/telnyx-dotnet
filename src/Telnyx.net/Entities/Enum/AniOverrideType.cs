namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AniOverrideType
    {
        [EnumMember(Value = "always")]
        Always = 0,
        [EnumMember(Value = "normal")]
        Normal = 1,
        [EnumMember(Value = "emergency")]
        Emergency = 2
    }
}
