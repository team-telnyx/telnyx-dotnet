using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.DynamicEmergencyAddresses
{
    public enum StatusFilter
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "activated")]
        Activated,

        [EnumMember(Value = "rejected")]
        Rejected
    }
}
