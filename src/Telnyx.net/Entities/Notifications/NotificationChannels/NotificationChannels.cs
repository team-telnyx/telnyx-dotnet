namespace Telnyx.net.Entities.Notifications.NotificationChannels
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationChannels;

    public class NotificationChannel : TelnyxEntity
    {
        /// <summary>
        /// The destination associated with the channel type.
        /// </summary>
        [JsonProperty("channel_destination")]
        public string ChannelDestination { get; set; }

        /// <summary>
        /// A Channel Type ID.
        /// </summary>
        [JsonProperty("channel_type_id")]
        public ChannelType ChannelTypeId { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// A UUID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A UUID reference to the associated Notification Profile.
        /// </summary>
        [JsonProperty("notification_profile_id")]
        public string NotificationProfileId { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}