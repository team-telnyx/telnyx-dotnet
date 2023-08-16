namespace Telnyx.net.Entities.Enum.NumberPortouts
{
    using System.Runtime.Serialization;

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
