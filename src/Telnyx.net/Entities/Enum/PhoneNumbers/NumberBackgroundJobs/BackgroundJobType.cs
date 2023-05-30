using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BackgroundJobType
    {
        [EnumMember(Value = "update_emergency_settings")]
        UpdateEmergencySettings,

        [EnumMember(Value = "delete_phone_numbers")]
        DeletePhoneNumbers,

        [EnumMember(Value = "update_phone_numbers")]
        UpdatePhoneNumbers
    }
}
