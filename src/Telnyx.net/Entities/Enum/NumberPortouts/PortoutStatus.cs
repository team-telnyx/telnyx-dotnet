using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.NumberPortouts
{
    public enum PortoutStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "authorized")]
        Authorized,

        [EnumMember(Value = "ported")]
        Ported,

        [EnumMember(Value = "rejected")]
        Rejected,

        [EnumMember(Value = "rejected-pending")]
        RejectedPending,

        [EnumMember(Value = "canceled")]
        Canceled
    }
}
