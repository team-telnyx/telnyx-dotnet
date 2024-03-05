namespace Telnyx.net.Services.Connections.IPs.Global
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.IPs.Global;
    public class GlobalIpLatencyService : Service<GlobalIpLatency>
    {
        public override string BasePath => "/global_ip_latency"; 

        public async Task<TelnyxList<GlobalIpLatency>> ListGlobalIpLatencyAsync(GlobalIpLatencyOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpLatency> ListGlobalIpLatency(GlobalIpLatencyOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

    }
}
