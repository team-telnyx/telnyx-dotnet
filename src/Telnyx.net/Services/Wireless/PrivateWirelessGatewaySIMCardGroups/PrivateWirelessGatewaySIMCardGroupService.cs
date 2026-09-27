using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.PrivateWirelessGatewaySIMCardGroups;

namespace Telnyx.net.Services.Wireless.PrivateWirelessGatewaySIMCardGroups
{
    public class PrivateWirelessGatewaySIMCardGroupService : ServiceNested<PrivateWirelessGatewaySIMCardGroup>
    {
        public override string BasePath => "/sim_card_groups/{PARENT_ID}/actions/set_private_wireless_gateway";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Ref: canonical action path parameter schema requires a UUID.
            if (!Guid.TryParse(parentId, out _))
            {
                throw new ArgumentException("The action parent ID must be a UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        public PrivateWirelessGatewaySIMCardGroup Create( string id, UpsertPrivateWirelessGatewaySIMCardGroup options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(id, options, requestOptions);
        }

        public async Task<PrivateWirelessGatewaySIMCardGroup> CreateAsync(string parentId, UpsertPrivateWirelessGatewaySIMCardGroup options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
