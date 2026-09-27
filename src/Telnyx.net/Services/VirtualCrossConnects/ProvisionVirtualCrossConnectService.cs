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

        public override string BasePath => "/virtual_cross_connects/{PARENT_ID}/actions/provision";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Archived ResourceId path parameter is a UUID.
            if (parentId == null || parentId.Length != 36 || !Guid.TryParseExact(parentId, "D", out _))
            {
                throw new ArgumentException("The virtual cross connect ID must be a hyphenated UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        // ... (other methods) ...

        // Method to update Allocatable Global Outbound Channels for a specific managed account
        public VirtualCrossConnect Create(string parentId, UpsertProvisionVirtualCrossConnect options, RequestOptions requestOptions)
        {
            // The archived provision operation has no requestBody; retain options for source compatibility.
            return BodylessActionRequest.Send<VirtualCrossConnect>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions));
        }

        public async Task<VirtualCrossConnect> CreateAsync(string parentId, UpsertProvisionVirtualCrossConnect options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await BodylessActionRequest.SendAsync<VirtualCrossConnect>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions), parentToken, cancellationToken);
        }

    }
}
