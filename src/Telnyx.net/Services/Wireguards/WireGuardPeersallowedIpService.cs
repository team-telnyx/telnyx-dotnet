using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.WireGuardPeersallowedIps;

namespace Telnyx.net.Services.PhoneNumbers.WireGuardPeersallowedIps
{
    public class WireGuardPeersallowedIpService : ServiceNested<WireGuardPeersAllowedIp>
    {
        public override string BasePath => "/wireguard_peers/:id/allowed_ips";

        public TelnyxList<WireGuardPeersAllowedIp> List(string id, WireGuardPeersAllowedIpOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<WireGuardPeersAllowedIp>> ListAsync(string id, WireGuardPeersAllowedIpOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }

    }
}
