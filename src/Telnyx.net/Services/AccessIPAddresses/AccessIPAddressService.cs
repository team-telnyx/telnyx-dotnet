using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Telnyx.net.Entities.AccessIPAddresses;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.AccessIPAddresses
{
    public class AccessIPAddressService : Service<AccessIPAddress>
    {

        public AccessIPAddressService()
           : base(null) { }

        public AccessIPAddressService(string apiKey)
            : base(apiKey) { }

        public override string BasePath => "/access_ip_address";
        public TelnyxList<AccessIPAddress> ListAllAccessIPAddresses(AccessIPAddressListOptions listOptions, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOptions, reqOpts);
        }

        public async Task<TelnyxList<AccessIPAddress>> ListAllAccessIPAddressesAsync(AccessIPAddressListOptions listOptions, RequestOptions reqOpts = null, string parentToken = "")
        {
            return await this.ListEntitiesAsync(listOptions, reqOpts, parentToken);
        }
        public AccessIPAddress CreateAllAccessIPAddresses(AccessIPAddressCreateOptions createOptions, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(createOptions, reqOpts);
        }

        public async Task <AccessIPAddress> CreateAllAccessIPAddressesAsync(AccessIPAddressCreateOptions createOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOpts, ct, parentToken: null);
        }
        public AccessIPAddress DeleteAllAccessIPAddresses(string id, RequestOptions requestOptions = null)
        {
            var a= this.DeleteEntity(id, requestOptions);
            return a;
        }

        public async Task <AccessIPAddress> DeleteAllAccessIPAddressesAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct).ConfigureAwait(false);
        }
        public async Task <AccessIPAddress> RetrieveAllAccessIPAddressesAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, string parentToken = "",CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken,ct);
        }
        public AccessIPAddress RetrieveAllAccessIPAddresses(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
    }
}
