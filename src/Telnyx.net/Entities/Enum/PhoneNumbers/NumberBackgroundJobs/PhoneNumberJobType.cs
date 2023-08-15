namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PhoneNumberJobType
    {
        [EnumMember(Value = "update_emergency_settings")]
        UpdateEmergencySettings,

        [EnumMember(Value = "delete_phone_numbers")]
        DeletePhoneNumbers,

        [EnumMember(Value = "update_phone_numbers")]
        UpdatePhoneNumbers
    }
}
