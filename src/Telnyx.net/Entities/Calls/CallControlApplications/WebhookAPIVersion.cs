namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WebhookAPIVersion
    {
        /// <summary>
        /// Enum V1 for 1
        /// </summary>
        [EnumMember(Value = "1")]
        V1 = 0,

        /// <summary>
        /// Enum V2 for 2
        /// </summary>
        [EnumMember(Value = "2")]
        V2 = 1,
    }
}
