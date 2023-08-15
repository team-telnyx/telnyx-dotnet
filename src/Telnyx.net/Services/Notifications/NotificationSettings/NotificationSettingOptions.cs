namespace Telnyx.net.Services.Notifications.NotificationSettings
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Notifications.NotificationSettings;

    public class NotificationSettingOptions : BaseOptions
    {
        /// <summary>
        /// A UUID reference to the associated Notification Channel.
        /// </summary>
        [JsonProperty("notification_channel_id")]
        public string NotificationChannelId { get; set; }

        /// <summary>
        /// A UUID reference to the associated Notification Event Condition.
        /// </summary>
        [JsonProperty("notification_event_condition_id")]
        public string NotificationEventConditionId { get; set; }

        /// <summary>
        /// A UUID reference to the associated Notification Profile.
        /// </summary>
        [JsonProperty("notification_profile_id")]
        public string NotificationProfileId { get; set; }

        /// <summary>
        /// An array of parameter objects.
        /// </summary>
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }
    }
}
