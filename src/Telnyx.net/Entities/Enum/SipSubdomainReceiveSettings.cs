namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// This option can be enabled to receive calls from: \"Anyone\" (any SIP endpoint in the public Internet) or \"Only my connections\" (any connection assigned to the same Telnyx user).
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SipSubdomainReceiveSettings
    {
        /// <summary>
        /// Enum OnlyMyConnections for only_my_connections
        /// </summary>
        [EnumMember(Value = "only_my_connections")]
        OnlyMyConnections = 0,

        /// <summary>
        /// Enum FromAnyone for from_anyone
        /// </summary>
        [EnumMember(Value = "from_anyone")]
        FromAnyone = 1,
    }
}
