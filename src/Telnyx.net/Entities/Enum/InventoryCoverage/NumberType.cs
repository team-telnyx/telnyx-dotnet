using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.InventoryCoverage
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NumberType
    {
        [EnumMember(Value = "did")]
        Did,
        [EnumMember(Value = "toll-free")]
        TollFree
    }
}
