namespace Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssociatedRecordType
    {
        [System.Runtime.Serialization.EnumMember(Value = "account")]
        Account,

        [System.Runtime.Serialization.EnumMember(Value = "phone_number")]
        PhoneNumber
    }
}
