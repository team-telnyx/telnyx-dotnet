namespace Telnyx
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Gets or sets RecordType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RecordTypeEnum
    {
        /// <summary>
        /// Enum NumberEnum for available_phone_number
        /// </summary>
        [EnumMember(Value = "available_phone_number")]
        NumberEnum = 0
    }
}
