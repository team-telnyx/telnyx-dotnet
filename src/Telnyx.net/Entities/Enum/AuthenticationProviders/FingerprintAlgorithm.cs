namespace Telnyx.net.Entities.Enum.AuthenticationProviders
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum FingerprintAlgorithm
    {
        [EnumMember(Value = "sha1")]
        Sha1,

        [EnumMember(Value = "sha256")]
        Sha256,

        [EnumMember(Value = "sha384")]
        sha384,

        [EnumMember(Value = "sha256")]
        sha256,

        [EnumMember(Value = "sha512")]
        sha512,
    }
}
