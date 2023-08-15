namespace Telnyx.net.Services.Notifications.NotificationSettings
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationSettings;

    public class NotificationSettingListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the id of a notification profile.
        /// </summary>
        [JsonProperty("filter[notification_profile_id][eq]")]
        public string NotificationProfileId { get; set; }

        /// <summary>
        /// Filter by the id of a notification channel.
        /// </summary>
        [JsonProperty("filter[notification_channel][eq]")]
        public string NotificationChannelId { get; set; }

        /// <summary>
        /// Filter by the id of a notification event condition.
        /// </summary>
        [JsonProperty("filter[notification_event_condition_id][eq]")]
        public string NotificationEventConditionId { get; set; }

        /// <summary>
        /// Filter by the associated record type.
        /// </summary>
        [JsonProperty("filter[associated_record_type][eq]")]
        public AssociatedRecordType AssociatedRecordType { get; set; }

        /// <summary>
        /// Filter by the status of a notification setting.
        /// </summary>
        [JsonProperty("filter[status][eq]")]
        public NotificationStatus NotificationStatus { get; set; }
    }
}
