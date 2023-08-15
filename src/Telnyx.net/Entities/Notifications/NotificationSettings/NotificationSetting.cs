namespace Telnyx.net.Entities.Notifications.NotificationSettings
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationSettings;

    public class NotificationSetting : TelnyxEntity
    {
        /// <summary>
        /// The type of the associated record.
        /// </summary>
        [JsonProperty("associated_record_type")]
        public AssociatedRecordType AssociatedRecordType { get; set; }

        /// <summary>
        /// The value of the associated record type.
        /// </summary>
        [JsonProperty("associated_record_type_value")]
        public string AssociatedRecordTypeValue { get; set; }

        /// <summary>
        /// The date and time when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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

        /// <summary>
        /// The status of the notification setting.
        /// </summary>
        [JsonProperty("status")]
        public NotificationStatus Status { get; set; }

        /// <summary>
        /// The date and time when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
