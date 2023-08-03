namespace Telnyx.net.Services.Connections.IPConnections
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.IPConnections;

    public class IPConnectionService : Service<IPConnection>
    {
        public override string BasePath => "/ip_connections";

        public async Task<TelnyxList<IPConnection>> ListIPConnectionsAsync(ConnectionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<IPConnection> ListIPConnections(ConnectionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<IPConnection> CreateIPConnectionAsync(UpsertIPConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, cancellationToken: ct);
        }

        public IPConnection CreateIPConnection(UpsertIPConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }

        public async Task<IPConnection> DeleteIPConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, string.Empty, ct);
        }

        public IPConnection DeleteIPConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }

        public async Task<IPConnection> RetrieveIPConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, string.Empty, ct);
        }

        public IPConnection RetrieveIPConnection(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }

        public async Task<IPConnection> UpdateIPConnectionAsync(string id, UpsertIPConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, string.Empty, ct);
        }

        public IPConnection UpdateIPConnection(string id, UpsertIPConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, string.Empty);
        }
    }
}
