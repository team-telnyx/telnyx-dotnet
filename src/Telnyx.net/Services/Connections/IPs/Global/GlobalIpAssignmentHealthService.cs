using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    public class GlobalIpAssignmentHealthService : Service<GlobalIpAssignmentHealth>
    {
        public override string BasePath => "/global_ip_assignment_health";

        public async Task<TelnyxList<GlobalIpAssignmentHealth>> ListIPsAsync(GlobalIpAssignmentHealthOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpAssignmentHealth> ListIPs(GlobalIpAssignmentHealthOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
