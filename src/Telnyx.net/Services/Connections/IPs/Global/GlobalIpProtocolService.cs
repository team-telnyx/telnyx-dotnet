using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    public class GlobalIpProtocolService : Service<GlobalIpProtocol>
    {
        public override string BasePath => "/global_ip_protocols"; // Set this to the actual endpoint

        public async Task<TelnyxList<GlobalIpProtocol>> ListProtocolsAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpProtocol> ListProtocols(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }

    }
}
