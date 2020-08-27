using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Telnyx.net.Entities.Enum.Messaging
{
    /// <summary>
    /// The direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DirectionEnum
    {
        /// <summary>
        /// Enum OutboundEnum for outbound
        /// </summary>
        [EnumMember(Value = "outbound")]
        OutboundEnum = 0,
        [EnumMember(Value = "inbound")]
        InboundEnum = 1,
    }
}