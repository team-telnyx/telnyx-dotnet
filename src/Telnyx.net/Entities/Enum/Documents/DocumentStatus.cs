using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

[JsonConverter(typeof(StringEnumConverter))]
public enum DocumentStatus
{
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "verified")]
    Verified,
    [EnumMember(Value = "denied")]
    Denied
}