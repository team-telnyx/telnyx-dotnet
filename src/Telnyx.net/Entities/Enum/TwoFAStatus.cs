using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Infrastructure.JsonConverters;

namespace Telnyx.net.Entities.Enum
{
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum TwoFAStatus
    {
        Unknown = -1,
        [EnumMember(Value = "pending")]
        Pending = 0,
        [EnumMember(Value = "sms_delivery_failed")]
        SmsDeliveryFailed = 1,
        [EnumMember(Value = "accepted")]
        Accepted = 2,
        [EnumMember(Value = "expired")]
        Expired = 3,
        [EnumMember(Value = "not_enough_credit")]
        NotEnoughCredit = 4,
        [EnumMember(Value = "network_error")]
        NetworkError = 5,
        [EnumMember(Value = "number_unreachable")]
        NumberUnreachable = 6,
        [EnumMember(Value = "internal_error")]
        InternalError = 7,
        [EnumMember(Value = "invalid_destination")]
        InvalidDestination = 8,
        [EnumMember(Value = "timed_out")]
        TimedOut = 9
    }
}
