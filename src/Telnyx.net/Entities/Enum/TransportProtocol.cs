namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
