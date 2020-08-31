using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DTMFType
    {
        [EnumMember(Value = "RFC 2833")]
        RFC_2833 = 0,
        [EnumMember(Value = "Inband")]
        Inband = 1,
        [EnumMember(Value = "SIP INFO")]
        SIP_Info = 2
    }
}
