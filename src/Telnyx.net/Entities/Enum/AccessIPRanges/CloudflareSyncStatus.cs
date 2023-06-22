using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Telnyx.net.Entities.Enum.AccessIPRanges
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CloudflareSyncStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "added")]
        Added
    }
}
