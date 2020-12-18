using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs;

namespace Telnyx.net.Services.Connections.IPs
{
    public class IPService : Service<IP>
    {
        public override string BasePath => "/ips";

        public async Task<TelnyxList<IP>> ListIPsAsync(IPListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<IP> ListIPs(IPListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<IP> CreateIPsAsync(UpsertIPOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public IP CreateIPs(UpsertIPOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
        public async Task<IP> DeleteIPsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public IP DeleteIPs(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
        public async Task<IP> RetrieveIPsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, ct);
        }
        public IP RetrieveIPs(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }
        public async Task<IP> UpdateIPsAsync(string id, UpsertIPOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, ct);
        }
        public IP UpdateIPs(string id, UpsertIPOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts);
        }
    }
}
