using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SimCardGroupActions
{
    public class SimCardGroupActionService : Service<SimCardGroupAction>
    {
        public override string BasePath => "/sim_card_group_actions";


        public async Task<TelnyxList<SimCardGroupAction>> ListSimCardGroupActionAsync(SimCardGroupActionOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<SimCardGroupAction> ListSimCardGroupAction(SimCardGroupActionOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<SimCardGroupAction> GetSimCardGroupActionAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public SimCardGroupAction GetSimCardGroupAction(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
