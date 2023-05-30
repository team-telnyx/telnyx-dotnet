using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments
{
    public enum CommentRecordType
    {
        [EnumMember(Value = "number_order")]
        NumberOrder,

        [EnumMember(Value = "sub_number_order")]
        SubNumberOrder,

        [EnumMember(Value = "number_order_phone_number")]
        NumberOrderPhoneNumber
    }
}
