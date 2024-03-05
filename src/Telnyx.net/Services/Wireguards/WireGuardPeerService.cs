using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.WireGuardPeers;

namespace Telnyx.net.Services.PhoneNumbers.WireGuardPeers
{
    public class WireGuardPeerService : Service<WireGuardPeer>
    {
        public override string BasePath => "/wireguard_peers";

        public async Task<TelnyxList<WireGuardPeer>> ListWireGuardPeerAsync(WireGuardPeerOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<WireGuardPeer> ListWireGuardPeer(WireGuardPeerOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<WireGuardPeer> GetWireGuardPeerAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public WireGuardPeer GetWireGuardPeer(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public WireGuardPeer DeleteWireGuardPeer(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<WireGuardPeer> DeleteWireGuardPeerAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<WireGuardPeer> UpdateWireGuardPeerAsync(string id, UpsertWireGuardPeer options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public WireGuardPeer UpdateWireGuardPeer(string id, UpsertWireGuardPeer options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
        public async Task<WireGuardPeer> CreateWireGuardPeerAsync(UpsertWireGuardPeer options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public WireGuardPeer CreateWireGuardPeer(UpsertWireGuardPeer options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
