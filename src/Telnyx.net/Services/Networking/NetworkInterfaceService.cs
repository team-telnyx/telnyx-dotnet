using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Networking.Networks;

namespace Telnyx.net.Services.Networking
{
    public class NetworkInterfaceService : ServiceNested<NetworkInterface>
    {
        
        public override string BasePath => "/networks/{PARENT_ID}/network_interfaces";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // The canonical ResourceId path parameter is a UUID, not an arbitrary path.
            if (parentId == null || parentId.Length != 36 || !System.Guid.TryParseExact(parentId, "D", out _))
            {
                throw new System.ArgumentException("The network ID must be a hyphenated UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

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
