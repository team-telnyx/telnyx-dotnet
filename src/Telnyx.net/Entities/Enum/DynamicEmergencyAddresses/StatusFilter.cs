namespace Telnyx.net.Entities.Enum.DynamicEmergencyAddresses
{
    using System.Runtime.Serialization;

    public enum StatusFilter
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "activated")]
        Activated,

        [EnumMember(Value = "rejected")]
        Rejected
    }
}
