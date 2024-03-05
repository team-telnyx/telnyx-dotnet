using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardNetworkPreference
{
    public class SIMCardDeleteNetworkPreferenceService : ServiceNested<SettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/:id/actions/delete_network_preferences";

        public SettingSIMCardPublicIP Create(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(id, options, requestOptions);
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
