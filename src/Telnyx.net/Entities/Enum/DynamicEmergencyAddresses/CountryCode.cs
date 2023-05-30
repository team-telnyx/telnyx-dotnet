using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.DynamicEmergencyAddresses
{
    public enum CountryCode
    {
        [EnumMember(Value = "US")]
        US,

        [EnumMember(Value = "CA")]
        CA,

        [EnumMember(Value = "PR")]
        PR
    }
}
