using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telnyx.net.Entities.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookUrlMethods
    {
        [EnumMember(Value = @"POST")]
        POST = 0,

        [EnumMember(Value = @"GET")]
        GET = 1,
    }
}
