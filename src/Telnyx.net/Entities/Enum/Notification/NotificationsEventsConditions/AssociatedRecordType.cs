namespace Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssociatedRecordType
    {
        [JsonProperty("account")]
        Account,

        [JsonProperty("phone_number")]
        PhoneNumber
    }
}
