namespace Telnyx.net.Entities.Enum.InventoryCoverage
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PhoneNumberType
    {
        [EnumMember(Value = "local")]
        Local,
        [EnumMember(Value = "toll_free")]
        TollFree,
        [EnumMember(Value = "national")]
        National,
        [EnumMember(Value = "landline")]
        Landline,
        [EnumMember(Value = "shared_cost")]
        SharedCost,
        [EnumMember(Value = "mobile")]
        Mobile
    }
}
