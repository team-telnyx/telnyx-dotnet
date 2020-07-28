namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;

    public class SimCardsService : Service<SimCardRecord>,
        IListable<SimCardRecord, ListOptions>,
        IDeletable<SimCardRecord>,
        IUpdatable<SimCardRecord, UpdateSimCardOptions>
    {
        public override string BasePath => "/sim_cards";

        public SimCardRecord Get(string id, BaseOptions baseOptions, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, baseOptions, requestOptions);
        }

        public async Task<SimCardRecord> GetAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, baseOptions, requestOptions, cancellationToken);
        }

        public TelnyxList<SimCardRecord> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<SimCardRecord>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        public SimCardRecord Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        public async Task<SimCardRecord> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }

        public SimCardRecord Update(string id, UpdateSimCardOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        public async Task<SimCardRecord> UpdateAsync(string id, UpdateSimCardOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }
    }
}
