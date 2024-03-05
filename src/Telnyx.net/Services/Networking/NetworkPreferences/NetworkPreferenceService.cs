using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Networking.NetworkPreferences;

namespace Telnyx.net.Services.Networking.NetworkPreferences
{
    public class NetworkPreferenceService : Service<NetworkPreference>
    {
        public override string BasePath => "/actions/network_preferences/sim_cards";

        public async Task<NetworkPreference> UpdateNetworkAsync(string id, UpsertNetworkPreference options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public NetworkPreference UpdateNetwork(string id, UpsertNetworkPreference options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
