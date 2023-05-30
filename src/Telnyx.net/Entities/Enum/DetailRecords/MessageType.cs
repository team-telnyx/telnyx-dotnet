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
