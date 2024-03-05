using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    public class GlobalIpUsageService : Service<GlobalIpUsage>
    {
        public override string BasePath => "/global_ip_usage"; // Adjust this path to your API's endpoint

        // Method for listing Global IP Usage entities with optional query parameters
        public async Task<TelnyxList<GlobalIpUsage>> ListGlobalIpUsageAsync(GlobalIpUsageOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpUsage> ListGlobalIpUsage(GlobalIpUsageOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
