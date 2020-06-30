using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.FQDNConnections;

namespace Telnyx.net.Services.Connections.FQDNConnections
{
    public class FQDNConnectionService : Service<FQDNConnection>
    {
        public override string BasePath => "/fqdn_connections";

        public async Task<TelnyxList<FQDNConnection>> ListFQDNConnectionAsync(ConnectionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<FQDNConnection> ListFQDNConnection(ConnectionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<FQDNConnection> CreateFQDNConnectionAsync(UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public FQDNConnection CreateFQDNConnection(UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
        public async Task<FQDNConnection> DeleteFQDNConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public FQDNConnection DeleteFQDNConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
        public async Task<FQDNConnection> RetrieveFQDNConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, ct);
        }
        public FQDNConnection RetrieveFQDNConnection(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }
        public async Task<FQDNConnection> UpdateFQDNConnectionAsync(string id, UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, ct);
        }
        public FQDNConnection UpdateFQDNConnection(string id, UpsertFQDNConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts);
        }
    }
}
