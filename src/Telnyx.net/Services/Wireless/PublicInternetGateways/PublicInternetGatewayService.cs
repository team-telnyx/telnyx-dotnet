using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.PublicInternetGateways;

namespace Telnyx.net.Services.Wireless.PublicInternetGateways
{
    public class PublicInternetGatewayService : Service<PublicInternetGateway>
    {
        public override string BasePath => "/public_internet_gateways";

        public async Task<TelnyxList<PublicInternetGateway>> ListPublicInternetGatewayAsync(PublicInternetGatewayOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<PublicInternetGateway> ListPublicInternetGateway(PublicInternetGatewayOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<PublicInternetGateway> GetPublicInternetGatewayAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PublicInternetGateway GetPublicInternetGateway(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public PublicInternetGateway DeletePublicInternetGateway(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<PublicInternetGateway> DeletePublicInternetGatewayAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<PublicInternetGateway> CreateNetworkAsync(UpsertPublicInternetGateway options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PublicInternetGateway CreateNetwork(UpsertPublicInternetGateway options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
