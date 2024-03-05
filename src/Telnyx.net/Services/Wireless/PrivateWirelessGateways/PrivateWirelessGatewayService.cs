using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.PrivateWirelessGateways;

namespace Telnyx.net.Services.Wireless.PrivateWirelessGateways
{
    public class PrivateWirelessGatewayService : Service<PrivateWirelessGateway>
    {
        public override string BasePath => "/private_wireless_gateways";

        public async Task<TelnyxList<PrivateWirelessGateway>> ListPrivateWirelessGatewayOptionAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<PrivateWirelessGateway> ListPrivateWirelessGatewayOption(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }

        public async Task<PrivateWirelessGateway> GetPrivateWirelessGatewayAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PrivateWirelessGateway GetPrivateWirelessGateway(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public PrivateWirelessGateway DeletePrivateWirelessGateway(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<PrivateWirelessGateway> DeletePrivateWirelessGatewayAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<PrivateWirelessGateway> CreatePrivateWirelessGatewayAsync(UpsertPrivateWirelessGateway options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PrivateWirelessGateway CreatePrivateWirelessGateway(UpsertPrivateWirelessGateway options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
