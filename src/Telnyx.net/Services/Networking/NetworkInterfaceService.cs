using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Networking.Networks;

namespace Telnyx.net.Services.Networking
{
    public class NetworkInterfaceService : ServiceNested<NetworkInterface>
    {
        
        public override string BasePath => "/networks/:id/network_interfaces";

        public TelnyxList<NetworkInterface> List(string id, NetworkInterfaceOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<NetworkInterface>> ListAsync(string id, NetworkInterfaceOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
