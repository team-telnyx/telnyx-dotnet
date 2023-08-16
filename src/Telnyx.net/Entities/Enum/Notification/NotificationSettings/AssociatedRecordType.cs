namespace Telnyx.net.Entities.Enum.Notification.NotificationSettings
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssociatedRecordType
    {
        [EnumMember(Value = "account")]
        Account,

        [EnumMember(Value = "phone_number")]
        PhoneNumber
    }
}
