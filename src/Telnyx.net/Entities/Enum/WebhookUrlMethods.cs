using System.Runtime.Serialization;

namespace Telnyx.net.Entities.Enum
{
    public enum WebhookUrlMethods
    {
        [EnumMember(Value = @"POST")]
        POST = 0,

        [EnumMember(Value = @"GET")]
        GET = 1,
    }
}
