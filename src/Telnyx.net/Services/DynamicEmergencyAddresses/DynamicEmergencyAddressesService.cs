namespace Telnyx.net.Services.DynamicEmergencyAddresses
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.DynamicEmergencyAddresses;

    public class DynamicEmergencyAddressesService : Service<DynamicEmergencyAddress>
    {
        public DynamicEmergencyAddressesService()
           : base(null)
        {
        }

        public DynamicEmergencyAddressesService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/dynamic_emergency_addresses";

        public async Task<TelnyxList<DynamicEmergencyAddress>> ListDynamicEmergencyAddresssAsync(DynamicEmergencyAddressListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<DynamicEmergencyAddress> ListDynamicEmergencyAddresss(DynamicEmergencyAddressListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts, string.Empty);
        }

        public async Task<DynamicEmergencyAddress> RetrieveDynamicEmergencyAddressAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, "data", ct);
        }

        public DynamicEmergencyAddress RetrieveDynamicEmergencyAddress(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, "data");
        }

        public DynamicEmergencyAddress CreateDynamicEmergencyAddress(CreateDynamicEmergencyAddressOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        public Task<DynamicEmergencyAddress> CreateDynamicEmergencyAddressAsync(CreateDynamicEmergencyAddressOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        public DynamicEmergencyAddress DeleteDynamicEmergencyAddress(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions, "data");
        }

        public async Task<DynamicEmergencyAddress> DeleteDynamicEmergencyAddressAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, "data", ct).ConfigureAwait(false);
        }
    }
}
