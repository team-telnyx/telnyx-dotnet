namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookUrlMethods
    {
        [EnumMember(Value = @"POST")]
        POST = 0,

        [EnumMember(Value = @"GET")]
        GET = 1,
    }
}
