using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DTMFType
    {
        RFC_2833 = 0,
        Inband = 1,
        SIP_Info = 2
    }
}
