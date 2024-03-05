using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    public class GlobalIpAssignmentUsageService : Service<GlobalIpAssignmentUsage>
    {
        public override string BasePath => "/global_ip_assignments_usage";

        public async Task<TelnyxList<GlobalIpAssignmentUsage>> ListGlobalIPsAssignmentAsync(GlobalIpAssignmentHealthOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpAssignmentUsage> ListGlobalIPsAssignment(GlobalIpAssignmentHealthOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
