namespace Telnyx.net.Entities.Enum.AccessIPRanges
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CloudflareSyncStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "added")]
        Added
    }
}
