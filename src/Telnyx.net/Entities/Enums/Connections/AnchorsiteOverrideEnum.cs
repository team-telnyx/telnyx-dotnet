using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enums.Connections
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AnchorsiteOverrideEnum
    {

        [EnumMember(Value = "Latency")]
        Latency = 0,
        [EnumMember(Value = "Chicago, IL")]
        ChicagoIL = 1,
        [EnumMember(Value = "Ashburn, VA")]
        AshburnVA = 2,
        [EnumMember(Value = "San Jose, CA")]
        SanJoseCA = 3,
        [EnumMember(Value = "Sydney, Australia")]
        SydneyAUS = 3,
        [EnumMember(Value = "Amsterdam, Netherlands")]
        AmsterdamNL = 5,
        [EnumMember(Value = "London, UK")]
        LondonUK = 6,
        [EnumMember(Value = "Toronto, Canada")]
        TorontoCA = 7,
        [EnumMember(Value = "Vancouver, Canada")]
        VancouverCA = 8,
        [EnumMember(Value = "Frankfurt, Germany")]
        FranfurtDE = 9,
    }
}
