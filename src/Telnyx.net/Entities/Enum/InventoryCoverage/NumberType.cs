namespace Telnyx.net.Entities.Enum.InventoryCoverage
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum NumberType
    {
        [EnumMember(Value = "did")]
        Did,
        [EnumMember(Value = "toll-free")]
        TollFree
    }
}
