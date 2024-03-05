using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces;

namespace Telnyx.net.Services.PhoneNumbers.WireGuardInterfaces
{
    public class WireGuardInterfaceService : Service<WireGuardInterface>
    {
        public override string BasePath => "/wireguard_interfaces";

        public async Task<TelnyxList<WireGuardInterface>> ListWireGuardInterfaceAsync(WireGuardInterfaceOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<WireGuardInterface> ListWireGuardInterface(WireGuardInterfaceOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<WireGuardInterface> GetWireGuardInterfaceAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public WireGuardInterface GetWireGuardInterface(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
        public WireGuardInterface DeleteWireGuardInterface(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<WireGuardInterface> DeleteWireGuardInterfaceAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<WireGuardInterface> CreateWireGuardInterfaceAsync(UpsertWireGuardInterface options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public WireGuardInterface CreateWireGuardInterface(UpsertWireGuardInterface options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
