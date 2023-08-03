namespace Telnyx.net.Entities.Notifications.NotificationsEventsConditions
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions;

    public class NotificationsEventsCondition : TelnyxEntity
    {
        /// <summary>
        /// Dictates whether a notification channel id needs to be provided when creating a notification setting.
        /// </summary>
        [JsonProperty("allow_multiple_channels")]
        public bool AllowMultipleChannels { get; set; }

        /// <summary>
        /// Enum: "account" "phone_number".
        /// </summary>
        [JsonProperty("associated_record_type")]
        public AssociatedRecordType AssociatedRecordType { get; set; }

        /// <summary>
        /// Dictates whether a notification setting will take effect immediately.
        /// </summary>
        [JsonProperty("asynchronous")]
        public bool Asynchronous { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The description of the notification setting.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Dictates whether the notification setting is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// A UUID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the notification setting.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The notification event ID.
        /// </summary>
        [JsonProperty("notification_event_id")]
        public string NotificationEventId { get; set; }

        /// <summary>
        /// Array of parameters.
        /// </summary>
        [JsonProperty("parameters")]
        public List<NotificationParameter> Parameters { get; set; }

        /// <summary>
        /// Array of supported notification channel types that can be emitted.
        /// </summary>
        [JsonProperty("supported_channels")]
        public string[] SupportedChannels { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
