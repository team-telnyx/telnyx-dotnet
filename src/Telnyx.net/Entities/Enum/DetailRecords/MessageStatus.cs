namespace Telnyx.net.Entities.Enum.DetailRecords
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageStatus
    {
        [EnumMember(Value = "gw_timeout")]
        GWTimeout,
        [EnumMember(Value = "delivered")]
        Delivered,
        [EnumMember(Value = "dlr_unconfirmed")]
        DlrUnconfirmed,
        [EnumMember(Value = "dlr_timeout")]
        DlrTimeout,
        [EnumMember(Value = "received")]
        Received,
        [EnumMember(Value = "gw_reject")]
        GWReject,
        [EnumMember(Value = "failed")]
        Failed
    }
}
