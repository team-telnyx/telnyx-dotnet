namespace Telnyx.net.Entities.Enum.NumberPortouts
{
    using System.Runtime.Serialization;

    public enum DocumentType
    {
        [EnumMember(Value = "loa")]
        LOA,

        [EnumMember(Value = "invoice")]
        Invoice
    }
}
