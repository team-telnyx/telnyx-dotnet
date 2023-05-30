using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.NumberOrderDocuments
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequirementType
    {
        [EnumMember(Value = "address_proof")]
        AddressProof,

        [EnumMember(Value = "identification")]
        Identification,

        [EnumMember(Value = "reg_form")]
        RegistrationForm
    }
}
