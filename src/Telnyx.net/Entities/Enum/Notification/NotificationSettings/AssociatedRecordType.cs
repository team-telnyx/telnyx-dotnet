using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Notification.NotificationSettings
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssociatedRecordType
    {
        [EnumMember(Value = "account")]
        Account,

        [EnumMember(Value = "phone_number")]
        PhoneNumber
    }
}
