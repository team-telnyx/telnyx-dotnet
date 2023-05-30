using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.DetailRecords
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecordType
    {
        [EnumMember(Value = "amd")]
        Amd,
        [EnumMember(Value = "conference")]
        Conference,
        [EnumMember(Value = "conference-participant")]
        ConferenceParticipant,
        [EnumMember(Value = "media_storage")]
        MediaStorage,
        [EnumMember(Value = "messaging")]
        Messaging,
        [EnumMember(Value = "verify")]
        Verify,
        [EnumMember(Value = "whatsapp")]
        Whatsapp,
        [EnumMember(Value = "whatsapp-conversation")]
        WhatsappConversation,
        [EnumMember(Value = "wireless")]
        Wireless
    }
}
