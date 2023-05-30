using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssociatedRecordType
    {
        [JsonProperty("account")]
        Account,

        [JsonProperty("phone_number")]
        PhoneNumber
    }
}
