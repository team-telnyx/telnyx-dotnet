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
