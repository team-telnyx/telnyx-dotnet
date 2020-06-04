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
    public enum TransportProtocol
    {
        [EnumMember(Value = "UDP")]
        UDP = 0,
        [EnumMember(Value = "TCP")]
        TCP = 1,
        [EnumMember(Value = "TLS")]
        TLS = 2
    }
}
