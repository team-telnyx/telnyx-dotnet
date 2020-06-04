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
    public enum AniOverrideType
    {
        [EnumMember(Value = "always")]
        Always = 0,
        [EnumMember(Value = "normal")]
        Normal = 1,
        [EnumMember(Value = "emergency")]
        Emergency = 2
    }
}
