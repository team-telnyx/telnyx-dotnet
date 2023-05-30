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
    public enum PhoneNumberType
    {
        [EnumMember(Value = "local")]
        Local,
        [EnumMember(Value = "toll_free")]
        TollFree,
        [EnumMember(Value = "national")]
        National,
        [EnumMember(Value = "landline")]
        Landline,
        [EnumMember(Value = "shared_cost")]
        SharedCost,
        [EnumMember(Value = "mobile")]
        Mobile
    }
}
