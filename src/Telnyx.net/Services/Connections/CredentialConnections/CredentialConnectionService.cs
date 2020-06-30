using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.CredentialConnections;

namespace Telnyx.net.Services.Connections.CredentialConnections
{
    public class CredentialConnectionService : Service<CredentialConnection>
    {
        public override string BasePath => "/credential_connections";

        public async Task<TelnyxList<CredentialConnection>> ListCredentialConnectionAsync(ConnectionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<CredentialConnection> ListCredentialConnection(ConnectionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<CredentialConnection> CreateCredentialConnectionAsync(UpsertCredentialConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public CredentialConnection CreateCredentialConnection(UpsertCredentialConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
        public async Task<CredentialConnection> DeleteCredentialConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public CredentialConnection DeleteCredentialConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
        public async Task<CredentialConnection> RetrieveCredentialConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, ct);
        }
        public CredentialConnection RetrieveCredentialConnection(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }
        public async Task<CredentialConnection> UpdateCredentialConnectionAsync(string id, UpsertCredentialConnectionOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, ct);
        }
        public CredentialConnection UpdateCredentialConnection(string id, UpsertCredentialConnectionOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts);
        }
    }
}
