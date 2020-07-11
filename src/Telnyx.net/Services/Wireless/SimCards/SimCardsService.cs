namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless;

    public class SimCardsService : Service<SimCardRecord>, IRetrievable<SimCardRecord>
    {
        public override string BasePath => "/sim_cards";

        public SimCardRecord Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<SimCardRecord> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, requestOptions, cancellationToken);
        }
    }
}
