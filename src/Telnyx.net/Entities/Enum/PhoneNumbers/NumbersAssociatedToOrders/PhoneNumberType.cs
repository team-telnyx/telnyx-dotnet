using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumbersAssociatedToOrders
{
    public enum PhoneNumberType
    {
        [EnumMember(Value = "local")]
        Local,
        [EnumMember(Value = "toll_free")]
        TollFree,
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "national")]
        National,
        [EnumMember(Value = "shared_cost")]
        SharedCost,
        [EnumMember(Value = "landline")]
        Landline
    }
}
