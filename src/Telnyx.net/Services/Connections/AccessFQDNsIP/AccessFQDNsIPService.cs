using System.Threading.Tasks;
using System.Threading;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.AccessFQDNsIP;
using Telnyx.net.Services.Connections.FQDNs;

namespace Telnyx.net.Services.Connections.AccessFQDNsIPs
{
    public class AccessFQDNsIPService : Service<AccessFQDNsIP>
    {
        public override string BasePath => "/access_fqdns/{fqdn_id}/ips";

        public TelnyxList<AccessFQDNsIP> ListFQDNs(string id, FQDNIPListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(BasePath, options, reqOpts, string.Empty, id);
        }

        public async Task<TelnyxList<AccessFQDNsIP>> ListFQDNsAsync(string id, FQDNIPListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(BasePath, options, reqOpts, string.Empty, id, ct);
        }



    }
}
