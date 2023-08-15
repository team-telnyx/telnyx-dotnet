namespace Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DynamicEmergencyAddressStatus
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "activated")]
        Activated,
        [EnumMember(Value = "rejected")]
        Rejected
    }
}
