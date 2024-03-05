using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telnyx.net.Entities;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Regions;

namespace Telnyx.net.Services.Regions
{
    public class RegionService : Service<Region>
    {
        public override string BasePath => "/regions";

        public async Task<TelnyxList<Region>> ListNumbersAssociatedToOrdersAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<Region> ListNumbersAssociatedToOrders(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }
    }
}
