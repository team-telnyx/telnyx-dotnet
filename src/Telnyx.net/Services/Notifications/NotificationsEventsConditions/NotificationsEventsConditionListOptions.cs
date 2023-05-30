using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions;

namespace Telnyx.net.Services.Notifications.NotificationsEventsConditions
{
    public class NotificationsEventsConditionListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the associated record type.
        /// </summary>
        [JsonProperty("filter[associated_record_type][eq]")]
        public AssociatedRecordType AssociatedRecordType { get; set; }
    }
}
