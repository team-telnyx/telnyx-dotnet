namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BackgroundJobStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "in_progress")]
        InProgress,

        [EnumMember(Value = "completed")]
        Completed,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "expired")]
        Expired
    }
}
