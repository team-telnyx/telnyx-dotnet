using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Messaging
{
    /// <summary>
    /// The line-type of the receiver.
    /// </summary>
    /// <value>The line-type of the receiver.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum LineTypeEnum
    {
        /// <summary>
        /// Enum WirelineEnum for Wireline
        /// </summary>
        [EnumMember(Value = "Wireline")]
        WirelineEnum = 0,

        /// <summary>
        /// Enum WirelessEnum for Wireless
        /// </summary>
        [EnumMember(Value = "Wireless")]
        WirelessEnum = 1,

        /// <summary>
        /// Enum VoWiFiEnum for VoWiFi
        /// </summary>
        [EnumMember(Value = "VoWiFi")]
        VoWiFiEnum = 2,

        /// <summary>
        /// Enum VoIPEnum for VoIP
        /// </summary>
        [EnumMember(Value = "VoIP")]
        VoIPEnum = 3,

        /// <summary>
        /// Enum PrePaidWirelessEnum for Pre-Paid Wireless
        /// </summary>
        [EnumMember(Value = "Pre-Paid Wireless")]
        PrePaidWirelessEnum = 4
    }

}
