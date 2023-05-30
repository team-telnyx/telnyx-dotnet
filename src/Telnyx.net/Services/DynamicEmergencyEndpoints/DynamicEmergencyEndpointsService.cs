using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.DynamicEmergencyEndpoints;

namespace Telnyx.net.Services.DynamicEmergencyEndpoints
{
    public class DynamicEmergencyEndpointsService : Service<DynamicEmergencyEndpoint>
    {
        public DynamicEmergencyEndpointsService()
           : base(null) { }

        public DynamicEmergencyEndpointsService(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "/dynamic_emergency_endpoints";
        public async Task<TelnyxList<DynamicEmergencyEndpoint>> ListDynamicEmergencyEndpointsAsync(DynamicEmergencyEndpointListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<DynamicEmergencyEndpoint> ListDynamicEmergencyEndpoints(DynamicEmergencyEndpointListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<DynamicEmergencyEndpoint> RetrieveDynamicEmergencyEndpointAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public DynamicEmergencyEndpoint RetrieveDynamicEmergencyEndpoint(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }

        public DynamicEmergencyEndpoint CreateDynamicEmergencyEndpoint(DynamicEmergencyEndpointOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        public Task<DynamicEmergencyEndpoint> CreateDynamicEmergencyEndpointAsync(DynamicEmergencyEndpointOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }

        public async Task<DynamicEmergencyEndpoint> DeleteCredentialConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public DynamicEmergencyEndpoint DeleteCredentialConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
    }
}
