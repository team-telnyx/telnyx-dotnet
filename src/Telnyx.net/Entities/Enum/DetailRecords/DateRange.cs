using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.DetailRecords
{
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
