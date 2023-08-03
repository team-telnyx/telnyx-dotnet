namespace Telnyx.net.Services.Notifications.NotificationChannels
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationChannels;

    public class NotificationChannelListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the id of a channel type Enum: "webhook" "sms" "email" "voice" Example: filter[channel_type_id][eq]=webhook.
        /// </summary>
        [JsonProperty("filter[channel_type_id][eq]")]
        public ChannelType TtlSeconds { get; set; }
    }
}