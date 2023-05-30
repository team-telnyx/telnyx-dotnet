using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.NumberPortouts
{
    public enum DocumentType
    {
        [EnumMember(Value = "loa")]
        LOA,

        [EnumMember(Value = "invoice")]
        Invoice
    }
}
