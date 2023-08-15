namespace Telnyx.net.Services.Connections.FQDNs
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.FQDNs;

    public class FQDNService : Service<FQDN>
    {
        public override string BasePath => "/fqdns";

        public async Task<TelnyxList<FQDN>> ListFQDNsAsync(FQDNListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<FQDN> ListFQDNs(FQDNListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<FQDN> CreateFQDNsAsync(UpsertFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public FQDN CreateFQDNs(UpsertFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<FQDN> DeleteFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public FQDN DeleteFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<FQDN> RetrieveFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public FQDN RetrieveFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, "data");
        }

        public async Task<FQDN> UpdateFQDNsAsync(string id, UpsertFQDNOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, "data", ct);
        }

        public FQDN UpdateFQDNs(string id, UpsertFQDNOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, "data");
        }
    }
}
