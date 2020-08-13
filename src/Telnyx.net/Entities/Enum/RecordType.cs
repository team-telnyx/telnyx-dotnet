using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum
{
    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecordType
    {
        [EnumMember(Value = "ip_connection")]
        IPConnection = 0,
        [EnumMember(Value = "call")]
        Call = 1,
        /// <summary>
        /// Enum NumberEnum for available_phone_number
        /// </summary>
        [EnumMember(Value = "available_phone_number")]
        NumberEnum = 2,
        /// <summary>
        /// Enum MessageEnum for message
        /// </summary>
        [EnumMember(Value = "message")]
        MessageEnum = 3,
        /// <summary>
        /// Enum NumberEnum for messaging_phone_number
        /// </summary>
        [EnumMember(Value = "messaging_phone_number")]
        MessagingPhoneNumberEnum = 4,
        /// <summary>
        /// Enum ProfileEnum for messaging_profile
        /// </summary>
        [EnumMember(Value = "messaging_profile")]
        ProfileEnum = 5,
        /// <summary>
        /// Enum CodeEnum for short_code
        /// </summary>
        [EnumMember(Value = "short_code")]
        CodeEnum = 6,
        [EnumMember(Value = "credential_connection")]
        CredentialConnection = 7,
        [EnumMember(Value = "fqdn_connection")]
        FQDNConnection = 8,
        [EnumMember(Value = "messaging_profile_metrics")]
        NessagingProfileMetrics = 9,
    }
}
