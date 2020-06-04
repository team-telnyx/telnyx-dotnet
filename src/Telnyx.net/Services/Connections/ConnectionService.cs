using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.ConnectionsService;
using Telnyx.net.Services.Connections.Options;

namespace Telnyx.net.Services.Connections
{
    public class ConnectionService : Service<Connection>
    {
        public override string BasePath => "/connections";

        public async Task<TelnyxList<Connection>> ListConnectionsAsync(ConnectionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<Connection> ListConnections(ConnectionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<Connection> RetrieveConnectionAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public Connection RetrieveConnection(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
    }
}
