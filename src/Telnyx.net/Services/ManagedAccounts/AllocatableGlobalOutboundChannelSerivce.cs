using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.ManagedAccounts;

namespace Telnyx.net.Services.ManagedAccounts
{
    public class AllocatableGlobalOutboundChannelService : Service<AllocatableGlobalOutboundChannel>
    {
        public override string BasePath => "/managed_accounts/allocatable_global_outbound_channels";

        // Method to list Allocatable Global Outbound Channels
        public async Task<TelnyxList<AllocatableGlobalOutboundChannel>> ListChannelsAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<AllocatableGlobalOutboundChannel> ListChannels(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }
    }
}
