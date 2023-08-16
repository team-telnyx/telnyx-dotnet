namespace Telnyx.net.Services.Connections.FQDNConnections
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.FQDNConnections;

    public class FQDNConnectionService : Service<FQDNConnection>
    {
        public override string BasePath => "/fqdn_connections";

        public async Task<TelnyxList<FQDNConnection>> ListFQDNConnectionAsync(ConnectionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<FQDNConnection> ListFQDNConnection(ConnectionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<FQDNConnection> CreateFQDNConnectionAsync(UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public FQDNConnection CreateFQDNConnection(UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<FQDNConnection> DeleteFQDNConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public FQDNConnection DeleteFQDNConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<FQDNConnection> RetrieveFQDNConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public FQDNConnection RetrieveFQDNConnection(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<FQDNConnection> UpdateFQDNConnectionAsync(string id, UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", ct);
        }

        public FQDNConnection UpdateFQDNConnection(string id, UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
