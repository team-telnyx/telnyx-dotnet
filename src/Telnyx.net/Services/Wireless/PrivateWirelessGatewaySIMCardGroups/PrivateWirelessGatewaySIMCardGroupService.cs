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
        public override string BasePath => "/sim_card_groups/:id/actions/set_private_wireless_gateway";

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
