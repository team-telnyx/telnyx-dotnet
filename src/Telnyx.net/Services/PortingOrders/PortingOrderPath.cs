using System;

namespace Telnyx.net.Services.PortingOrders
{
    internal static class PortingOrderPath
    {
        internal static void ValidateId(string parentId)
        {
            Guid id;
            // Canonical PathPortingOrderID is a UUID; never normalize URL fragments.
            if (parentId == null || parentId.Length != 36 || !Guid.TryParseExact(parentId, "D", out id))
            {
                throw new ArgumentException("A hyphenated porting-order UUID is required.", nameof(parentId));
            }
        }
    }
}
