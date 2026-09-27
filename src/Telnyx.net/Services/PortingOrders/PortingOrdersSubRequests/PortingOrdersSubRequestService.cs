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
        public override string BasePath => "/porting_orders/{PARENT_ID}/sub_request";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            PortingOrderPath.ValidateId(parentId);
            return base.ClassUrl(parentId, baseUrl);
        }

        /// <inheritdoc/>
        public PortingOrdersSubRequest Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetRequest<PortingOrdersSubRequest>(this.ClassUrl(id), null, requestOptions, false, "data");
        }

        /// <inheritdoc/>
        public async Task<PortingOrdersSubRequest> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<PortingOrdersSubRequest>(this.ClassUrl(id), null, requestOptions, false, "data", cancellationToken);
        }
    }
}
