namespace Telnyx.net.Services.Notifications.NotificationsEventsConditions
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions;

    public class NotificationsEventsConditionListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the associated record type.
        /// </summary>
        [JsonProperty("filter[associated_record_type][eq]")]
        public AssociatedRecordType AssociatedRecordType { get; set; }
    }
}
