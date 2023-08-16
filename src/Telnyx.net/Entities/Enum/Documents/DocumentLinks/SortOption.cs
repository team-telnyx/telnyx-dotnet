namespace Telnyx.net.Entities.Enum.Documents.DocumentLinks
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOption
    {
        [EnumMember(Value = "filename")]
        Filename,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "updated_at")]
        UpdatedAt
    }
}
