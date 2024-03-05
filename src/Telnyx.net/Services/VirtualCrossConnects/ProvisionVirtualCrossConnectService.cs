using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.VirtualCrossConnects;

namespace Telnyx.net.Services.VirtualCrossConnects
{
    public class ProvisionVirtualCrossConnectService : ServiceNested<VirtualCrossConnect>
    {

        public override string BasePath => "/virtual_cross_connects/:id/actions/provision";

        // ... (other methods) ...

        // Method to update Allocatable Global Outbound Channels for a specific managed account
        public VirtualCrossConnect Create(string parentId, UpsertProvisionVirtualCrossConnect options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<VirtualCrossConnect> CreateAsync(string parentId, UpsertProvisionVirtualCrossConnect options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }

    }
}
