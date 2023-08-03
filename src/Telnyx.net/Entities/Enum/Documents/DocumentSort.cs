namespace Telnyx.net.Entities.Enum.Documents
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
