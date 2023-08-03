namespace Telnyx.net.Entities.Enum.DetailRecords
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
