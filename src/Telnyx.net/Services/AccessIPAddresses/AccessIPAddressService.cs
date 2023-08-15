namespace Telnyx.net.Services.AccessIPAddresses
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AccessIPAddresses;

    public class AccessIPAddressService : Service<AccessIPAddress>
    {

        public AccessIPAddressService()
           : base(null)
        {
        }

        public AccessIPAddressService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/access_ip_address";

        public TelnyxList<AccessIPAddress> ListAllAccessIPAddresses(AccessIPAddressListOptions listOptions, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOptions, reqOpts);
        }

        public async Task<TelnyxList<AccessIPAddress>> ListAllAccessIPAddressesAsync(AccessIPAddressListOptions listOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOpts, string.Empty, ct);
        }

        public AccessIPAddress CreateAllAccessIPAddresses(AccessIPAddressCreateOptions createOptions, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(createOptions, reqOpts);
        }

        public async Task<AccessIPAddress> CreateAllAccessIPAddressesAsync(AccessIPAddressCreateOptions createOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOpts, parentToken: null, cancellationToken: ct);
        }

        public AccessIPAddress DeleteAllAccessIPAddresses(string id, RequestOptions requestOptions = null)
        {
            var a = this.DeleteEntity(id, requestOptions);
            return a;
        }

        public async Task<AccessIPAddress> DeleteAllAccessIPAddressesAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        public async Task<AccessIPAddress> RetrieveAllAccessIPAddressesAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, string.Empty, ct);
        }

        public AccessIPAddress RetrieveAllAccessIPAddresses(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, string.Empty);
        }
    }
}
