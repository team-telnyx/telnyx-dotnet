namespace Telnyx.net.Entities.Enum.DynamicEmergencyAddresses
{
    using System.Runtime.Serialization;

    public enum CountryCode
    {
        [EnumMember(Value = "US")]
        US,

        [EnumMember(Value = "CA")]
        CA,

        [EnumMember(Value = "PR")]
        PR
    }
}
