using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardNetworkPreference
{
    public class SIMCardNetworkPreferenceService : ServiceNested<SettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/:id/actions/set_network_preferences";

        public SettingSIMCardPublicIP Create(string parentId, string id, UpsertSIMCardNetworkPreference options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, UpsertSIMCardNetworkPreference options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
