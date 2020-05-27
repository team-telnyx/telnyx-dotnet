namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    /// <value>Determines which webhook format will be used, Telnyx API v1 or v2.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WebhookAPIVersion
    {
        /// <summary>
        /// Enum _1Enum for 1
        /// </summary>
        [EnumMember(Value = "1")]
        _1Enum = 0,

        /// <summary>
        /// Enum _2Enum for 2
        /// </summary>
        [EnumMember(Value = "2")]
        _2Enum = 1,
    }
}
