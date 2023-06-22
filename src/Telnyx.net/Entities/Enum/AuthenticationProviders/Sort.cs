using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Telnyx.net.Entities.Enum.AuthenticationProviders
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum Sort
    {
        [EnumMember(Value = "name")]
        Name,

        [EnumMember(Value = "short_name")]
        ShortName,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "created_at")]
        CreatedAt,

        [EnumMember(Value = "updated_at")]
        UpdatedAt,
    }
}
