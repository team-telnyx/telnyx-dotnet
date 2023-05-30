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
    public enum NotificationStatus
    {
        [EnumMember(Value = "enabled")]
        Enabled,

        [EnumMember(Value = "enable-received")]
        EnableReceived,

        [EnumMember(Value = "enable-pending")]
        EnablePending,

        [EnumMember(Value = "enable-submitted")]
        EnableSubmitted,

        [EnumMember(Value = "delete-received")]
        DeleteReceived,

        [EnumMember(Value = "delete-pending")]
        DeletePending,

        [EnumMember(Value = "delete-submitted")]
        DeleteSubmitted,

        [EnumMember(Value = "deleted")]
        Deleted
    }
}
