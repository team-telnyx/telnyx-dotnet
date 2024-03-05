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
        public override string BasePath => "/porting_orders/:id/actions/activate";

        public PortingOrderActivate Create(string parentId, UpsertPortingOrders options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<PortingOrderActivate> CreateAsync(string parentId, UpsertPortingOrders options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
