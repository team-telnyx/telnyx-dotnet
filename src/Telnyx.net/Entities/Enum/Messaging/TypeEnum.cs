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
    /// The type of message. This value can be either 'sms' or 'mms'.
    /// </summary>
    /// <value>This value can be either 'sms' or 'mms'.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TypeEnum
    {
        /// <summary>
        /// Enum SmsEnum for sms
        /// </summary>
        [EnumMember(Value = "sms")]
        SmsEnum = 0,

        /// <summary>
        /// Enum MmsEnum for mms
        /// </summary>
        [EnumMember(Value = "mms")]
        MmsEnum = 1
    }
}
