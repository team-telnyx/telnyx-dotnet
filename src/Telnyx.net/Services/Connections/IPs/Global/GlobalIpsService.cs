using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs.Global;

namespace Telnyx.net.Services.Connections.IPs.Global
{
    public class GlobalIpsService : Service<GlobalIpsResponse>
    {
        public override string BasePath => "/global_ips"; // Adjust to the actual API endpoint for global IP resources

        // Create a new Global IP resource
        public async Task<GlobalIpsResponse> CreateGlobalIpAsync(UpsertGlobalIps options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, parentToken: "data", cancellationToken);
        }

        public GlobalIpsResponse CreateGlobalIp(UpsertGlobalIps options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, parentToken: "data");
        }

        // Update an existing Global IP resource
        public async Task<GlobalIpsResponse> UpdateGlobalIpAsync(string id, UpsertGlobalIps options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, options, requestOptions, parentToken: "data", cancellationToken);
        }

        public GlobalIpsResponse UpdateGlobalIp(string id, UpsertGlobalIps options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, options, requestOptions, parentToken: "data");
        }

        // Retrieve a single Global IP resource by ID
        public async Task<GlobalIpsResponse> GetGlobalIpAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public GlobalIpsResponse GetGlobalIp(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        // Delete a Global IP resource
        public async Task<GlobalIpsResponse> DeleteGlobalIpAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        public GlobalIpsResponse DeleteGlobalIp(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        // List all Global IP resources
        public async Task<TelnyxList<GlobalIpsResponse>> ListGlobalIpsAsync(ListOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }

        public TelnyxList<GlobalIpsResponse> ListGlobalIps(ListOptions options, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }
    }
}
