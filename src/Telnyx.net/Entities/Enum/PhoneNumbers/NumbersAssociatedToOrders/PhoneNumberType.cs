namespace Telnyx.net.Entities.Enum.PhoneNumbers.NumbersAssociatedToOrders
{
    using System.Runtime.Serialization;

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
