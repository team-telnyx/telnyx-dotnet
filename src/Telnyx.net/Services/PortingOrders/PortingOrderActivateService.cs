using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PortingOrders;

namespace Telnyx.net.Services.PortingOrders
{
    public class PortingOrderActivateService : ServiceNested<PortingOrderActivate>
    {
        public override string BasePath => "/porting_orders/{PARENT_ID}/actions/activate";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            PortingOrderPath.ValidateId(parentId);
            return base.ClassUrl(parentId, baseUrl);
        }

        public PortingOrderActivate Create(string parentId, UpsertPortingOrders options, RequestOptions requestOptions)
        {
            return this.PostRequest<PortingOrderActivate>(this.ClassUrl(parentId), null, requestOptions, parentToken: "data");
        }

        public async Task<PortingOrderActivate> CreateAsync(string parentId, UpsertPortingOrders options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, null, requestOptions, string.IsNullOrEmpty(parentToken) ? "data" : parentToken, cancellationToken);
        }
    }
}
