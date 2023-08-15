namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Infrastructure.JsonConverters;

    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum ConferenceStatus
    {
        Unknown = -1,
        [EnumMember(Value = "init")]
        Init = 1,
        [EnumMember(Value = "in_progress")]
        InProgress = 2,
        [EnumMember(Value = "completed")]
        Completed = 3,
    }
}
