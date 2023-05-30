using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Notification.NotificationChannels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelType
    {
        [EnumMember(Value = "webhook")]
        Webhook,

        [EnumMember(Value = "sms")]
        SMS,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "voice")]
        Voice
    }
}