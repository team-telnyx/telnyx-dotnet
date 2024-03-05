using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    internal class GlobalIpService : Service<GlobalIPs>
    {
        public override string BasePath => "/global_ips";

        public async Task<TelnyxList<GlobalIPs>> ListGlobalIPsAsync(ListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIPs> ListGlobalIPs(ListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
