using System.Runtime.Serialization;
using Newtonsoft.Json;
using Telnyx.net.Infrastructure.JsonConverters;

namespace Telnyx.net.Entities.Enum
{
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum NumberOrderStatus
    {
        Unknown = -1,
        [EnumMember(Value = "pending")]
        Pending = 0,
        [EnumMember(Value = "deleted")]
        Deleted = 1,
        [EnumMember(Value = "failed")]
        Failed = 2,
        [EnumMember(Value = "successful")]
        successful = 3,
    }
}
