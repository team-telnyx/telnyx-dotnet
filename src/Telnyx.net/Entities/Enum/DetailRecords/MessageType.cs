namespace Telnyx.net.Entities.Enum.DetailRecords
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "SMS")]
        SMS,
        [EnumMember(Value = "MMS")]
        MMS,
        [EnumMember(Value = "RCS")]
        RCS
    }
}
