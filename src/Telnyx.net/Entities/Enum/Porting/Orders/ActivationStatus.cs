using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Infrastructure.JsonConverters;

namespace Telnyx.net.Entities.Enum.Porting.Orders
{
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum ActivationStatus
    {
        Unknown = -1,
        [EnumMember(Value = "New")]
        New = 0,
        [EnumMember(Value = "Pending")]
        Pending = 1,
        [EnumMember(Value = "Conflict")]
        Conflict = 2,
        [EnumMember(Value = "Cancel Pending")]
        CancelPending = 3,
        [EnumMember(Value = "Failed")]
        Failed = 4,
        [EnumMember(Value = "Concurred")]
        Concurred = 5,
        [EnumMember(Value = "Activate RDY")]
        ActivateRDY = 6,
        [EnumMember(Value = "Disconnect Pending")]
        DisconnectPending = 7,
        [EnumMember(Value = "Concurrence Sent")]
        ConcurrenceSent = 8,
        [EnumMember(Value = "Old")]
        Old = 9,
        [EnumMember(Value = "Sending")]
        Sending = 10,
        [EnumMember(Value = "Active")]
        Active = 11,
        [EnumMember(Value = "Cancelled")]
        Cancelled = 12
    }
}
