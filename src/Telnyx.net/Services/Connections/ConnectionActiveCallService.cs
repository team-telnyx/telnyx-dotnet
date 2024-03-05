using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections;

namespace Telnyx.net.Services.Connections
{
    public class ConnectionActiveCallService : ServiceNested<ConnectionActiveCall>
    {
        public override string BasePath => "/connections/:connection_id/active_calls";

        public TelnyxList<ConnectionActiveCall> List(string id, ConnectionActiveCallOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<ConnectionActiveCall>> ListAsync(string id, ConnectionActiveCallOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
