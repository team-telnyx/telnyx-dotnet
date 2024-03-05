using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PortingOrders.PortingOrdersSubRequests;

namespace Telnyx.net.Services.PortingOrders.PortingOrdersSubRequests
{
    public class PortingOrdersSubRequestService : ServiceNested<PortingOrdersSubRequest>
    {
        public override string BasePath => "/porting_orders/:id/sub_request";

        /// <inheritdoc/>
        public PortingOrdersSubRequest Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(id, null, null, requestOptions, "data");
        }

        /// <inheritdoc/>
        public async Task<PortingOrdersSubRequest> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, string.Empty, cancellationToken);
        }
    }
}
