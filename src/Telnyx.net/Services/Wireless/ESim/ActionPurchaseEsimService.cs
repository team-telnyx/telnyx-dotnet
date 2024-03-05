using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.ESim.ActionPurchaseEsims;

namespace Telnyx.net.Services.Wireless.ESim
{
    public class ActionPurchaseEsimService : Service<ActionPurchaseEsim>
    {
        public override string BasePath => "/actions/purchase/esims";

        public async Task<ActionPurchaseEsim> CreateActionPurchaseEsimAsync(UpsertActionPurchaseEsim options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public ActionPurchaseEsim CreateActionPurchaseEsim(UpsertActionPurchaseEsim options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
