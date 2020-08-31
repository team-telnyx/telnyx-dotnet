using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.FQDNs;

namespace Telnyx.net.Services.Connections.FQDNs
{
    public class FQDNService : Service<FQDN>
    {
        public override string BasePath => "/fqdns";

        public async Task<TelnyxList<FQDN>> ListFQDNsAsync(FQDNListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<FQDN> ListFQDNs(FQDNListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<FQDN> CreateFQDNsAsync(UpsertFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public FQDN CreateFQDNs(UpsertFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
        public async Task<FQDN> DeleteFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public FQDN DeleteFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
        public async Task<FQDN> RetrieveFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, ct);
        }
        public FQDN RetrieveFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }
        public async Task<FQDN> UpdateFQDNsAsync(string id, UpsertFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, ct);
        }
        public FQDN UpdateFQDNs(string id, UpsertFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts);
        }
    }
}
