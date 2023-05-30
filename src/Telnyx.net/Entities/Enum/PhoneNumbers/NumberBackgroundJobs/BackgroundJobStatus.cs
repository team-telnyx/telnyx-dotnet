using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs
{
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
