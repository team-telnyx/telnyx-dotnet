using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VirtualCrossConnects;

namespace Telnyx.net.Services.VirtualCrossConnects
{
    public class VirtualCrossConnectService : Service<VirtualCrossConnect>
    {
        public override string BasePath => "/virtual_cross_connects";

        public async Task<TelnyxList<VirtualCrossConnect>> ListVirtualCrossConnectAsync(VirtualCrossConnectOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<VirtualCrossConnect> ListVirtualCrossConnect(VirtualCrossConnectOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<VirtualCrossConnect> GetVirtualCrossConnectAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public VirtualCrossConnect GetVirtualCrossConnect(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }


        public VirtualCrossConnect DeleteVirtualCrossConnect(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<VirtualCrossConnect> DeleteVirtualCrossConnectAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<VirtualCrossConnect> CreateVirtualCrossConnectAsync(UpsertVirtualCrossConnect options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public VirtualCrossConnect CreateVirtualCrossConnect(UpsertVirtualCrossConnect options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<VirtualCrossConnect> UpdateVirtualCrossConnectAsync(string id, UpdateVirtualCrossConnect options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public VirtualCrossConnect UpdateVirtualCrossConnect(string id, UpdateVirtualCrossConnect options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
