using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Notification.NotificationChannels;

namespace Telnyx.net.Services.Notifications.NotificationChannels
{
    public class NotificationChannelListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the id of a channel type Enum: "webhook" "sms" "email" "voice" Example: filter[channel_type_id][eq]=webhook
        /// </summary>
        [JsonProperty("filter[channel_type_id][eq]")]
        public ChannelType TtlSeconds { get; set; }
    }
}