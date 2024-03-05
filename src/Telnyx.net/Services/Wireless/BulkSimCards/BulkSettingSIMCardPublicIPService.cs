using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.BulkSettingSIMCardPublicIPs;

namespace Telnyx.net.Services.PhoneNumbers.BulkSettingSIMCardPublicIPs
{
    public class BulkSettingSIMCardPublicIPService : Service<BulkSettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/actions/bulk_set_public_ips";

        public async Task<BulkSettingSIMCardPublicIP> CreateBulkSettingSIMCardPublicIPAsync(UpsertBulkSettingSIMCardPublicIP options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public BulkSettingSIMCardPublicIP CreateBulkSettingSIMCardPublicIP(UpsertBulkSettingSIMCardPublicIP options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
