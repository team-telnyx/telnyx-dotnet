namespace Telnyx.net.Entities.Enum.Transcriptions
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Infrastructure.JsonConverters;

    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum Languages
    {
        Unknown = -1,
        [EnumMember(Value = "en")]
        English = 0,
        [EnumMember(Value = "de")]
        German = 1,
        [EnumMember(Value = "es")]
        Spanish = 2,
        [EnumMember(Value = "fr")]
        French = 3,
        [EnumMember(Value = "it")]
        Italian = 4,
        [EnumMember(Value = "pl")]
        Polish = 5,
    }
}
