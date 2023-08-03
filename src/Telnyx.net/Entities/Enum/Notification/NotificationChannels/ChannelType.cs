namespace Telnyx.net.Entities.Enum.Notification.NotificationChannels
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelType
    {
        [EnumMember(Value = "webhook")]
        Webhook,

        [EnumMember(Value = "sms")]
        SMS,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "voice")]
        Voice
    }
}