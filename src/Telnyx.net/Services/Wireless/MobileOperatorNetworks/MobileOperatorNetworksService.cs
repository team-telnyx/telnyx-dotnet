namespace Telnyx.net.Services.Wireless.MobileOperatorNetworks
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.MobileOperatorNetworks;

    public class MobileOperatorNetworksService : Service<MobileOperatorNetworksRecord>,
        IListable<MobileOperatorNetworksRecord, ListMobileOperatorNetworksOptions>
    {
        public override string BasePath => "/mobile_operator_networks";

        public TelnyxList<MobileOperatorNetworksRecord> List(ListMobileOperatorNetworksOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<MobileOperatorNetworksRecord>> ListAsync(ListMobileOperatorNetworksOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
