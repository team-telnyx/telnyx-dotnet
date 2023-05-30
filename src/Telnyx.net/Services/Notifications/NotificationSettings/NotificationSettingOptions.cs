using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Notification.NotificationSettings;
using Telnyx.net.Entities.Notifications.NotificationSettings;

namespace Telnyx.net.Services.Notifications.NotificationSettings
{
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
