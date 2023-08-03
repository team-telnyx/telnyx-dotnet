namespace Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments
{
    using System.Runtime.Serialization;

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
