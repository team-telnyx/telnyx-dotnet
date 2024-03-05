using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.ManagedAccounts;

namespace Telnyx.net.Services.ManagedAccounts
{
    public class UpdateAllocatableGlobalOutboundChannelService : Service<AllocatableGlobalOutboundChannelResponse>
    {
        public override string BasePath => "/managed_accounts/{id}/update_global_channel_limit";

        // ... (other methods) ...

        // Method to update Allocatable Global Outbound Channels for a specific managed account
        public async Task<AllocatableGlobalOutboundChannelResponse> UpdateChannelAsync(string id, UpsertAllocatableGlobalOutboundChannel options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, options, requestOptions, "data", cancellationToken);

        }

        public AllocatableGlobalOutboundChannelResponse UpdateChannel(string id, UpsertAllocatableGlobalOutboundChannel options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, options, requestOptions, "data");
        }
    }
}
