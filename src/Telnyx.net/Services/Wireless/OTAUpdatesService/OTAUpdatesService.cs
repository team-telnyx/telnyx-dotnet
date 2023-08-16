namespace Telnyx.net.Services.Wireless.OTAUpdatesService
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.OTAUpdates;

    public class OTAUpdatesService : Service<OTAUpdatesRecord>,
        IRetrievable<OTAUpdatesRecord>,
        IListable<OTAUpdatesRecord, ListOTAUpdatesOptions>
    {
        public override string BasePath => "/ota_updates";

        public OTAUpdatesRecord Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<OTAUpdatesRecord> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public TelnyxList<OTAUpdatesRecord> List(ListOTAUpdatesOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<OTAUpdatesRecord>> ListAsync(ListOTAUpdatesOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
