using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Documents
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DocumentSort
    {
        [EnumMember(Value = "filename")]
        Filename,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "updated_at")]
        UpdatedAt
    }
}
