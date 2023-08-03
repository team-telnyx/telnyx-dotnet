namespace Telnyx.net.Entities.Enum.NumberOrderDocuments
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
