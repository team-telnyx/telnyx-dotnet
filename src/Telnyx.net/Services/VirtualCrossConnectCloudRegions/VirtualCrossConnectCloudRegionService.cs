using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VirtualCrossConnectCloudRegions;

namespace Telnyx.net.Services.VirtualCrossConnectCloudRegions
{
    public class VirtualCrossConnectCloudRegionService : Service<VirtualCrossConnectCloudRegion>
    {
        public override string BasePath => "/virtual_cross_connect_regions";
        public async Task<TelnyxList<VirtualCrossConnectCloudRegion>> ListVirtualCrossConnectCloudRegionAsync(VirtualCrossConnectCloudRegionOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<VirtualCrossConnectCloudRegion> ListVirtualCrossConnectCloudRegion(VirtualCrossConnectCloudRegionOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<VirtualCrossConnectCloudRegion> GetVirtualCrossConnectCloudRegionAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public VirtualCrossConnectCloudRegion GetVirtualCrossConnectCloudRegion(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
