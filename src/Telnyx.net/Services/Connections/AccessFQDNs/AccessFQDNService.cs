using System.Threading.Tasks;
using System.Threading;
using Telnyx.net.Entities.Connections.AccessFQDNs;
using Telnyx.net.Entities;
using Telnyx.net.Services.Connections.FQDNs;

namespace Telnyx.net.Services.Connections.AccessFQDNs
{
    public class AccessFQDNService : Service<AccessFQDN>
    {
        public override string BasePath => "/access_fqdns";

        public async Task<TelnyxList<AccessFQDN>> ListAccessFQDNsAsync(AccessFQDNListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<AccessFQDN> ListAccessFQDNs(AccessFQDNListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<AccessFQDN> CreateFQDNsAsync(UpsertAccessFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public AccessFQDN CreateFQDNs(UpsertAccessFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<AccessFQDN> DeleteAccessFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public AccessFQDN DeleteAccessFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<AccessFQDN> RetrieveAccessFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public AccessFQDN AccessRetrieveFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, "data");
        }

        public async Task<AccessFQDN> UpdateFQDNsAsync(string id, UpsertAccessFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, "data", ct);
        }

        public AccessFQDN UpdateFQDNs(string id, UpsertAccessFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, "data");
        }

    }
}
