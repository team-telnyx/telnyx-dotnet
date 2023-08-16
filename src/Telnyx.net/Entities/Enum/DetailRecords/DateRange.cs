namespace Telnyx.net.Entities.Enum.DetailRecords
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DateRange
    {
        [EnumMember(Value = "yesterday")]
        Yesterday,
        [EnumMember(Value = "today")]
        Today,
        [EnumMember(Value = "tomorrow")]
        Tomorrow,
        [EnumMember(Value = "last_week")]
        LastWeek,
        [EnumMember(Value = "this_week")]
        ThisWeek,
        [EnumMember(Value = "next_week")]
        NextWeek,
        [EnumMember(Value = "last_month")]
        LastMonth,
        [EnumMember(Value = "this_month")]
        ThisMonth,
        [EnumMember(Value = "next_month")]
        NextMonth
    }
}
