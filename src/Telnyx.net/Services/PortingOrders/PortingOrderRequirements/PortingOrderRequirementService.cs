using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PortingOrders.PortingOrderRequirements;

namespace Telnyx.net.Services.PortingOrders.PortingOrderRequirements
{
    public class PortingOrderRequirementService : ServiceNested<PortingOrderRequirement>
    {
        public override string BasePath => "/porting_orders/:id/requirements";

        public TelnyxList<PortingOrderRequirement> List(string id, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<PortingOrderRequirement>> ListAsync(string id, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
