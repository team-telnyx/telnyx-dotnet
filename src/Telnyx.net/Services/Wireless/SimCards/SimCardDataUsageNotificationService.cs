using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SimCardDataUsageNotifications
{
    public class SimCardDataUsageNotificationService : Service<SimCardDataUsageNotification>
    {
        public override string BasePath => "/sim_card_data_usage_notifications";

        public async Task<TelnyxList<SimCardDataUsageNotification>> ListSimCardDataUsageNotificationAsync(SimCardDataUsageNotificationOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<SimCardDataUsageNotification> ListSimCardDataUsageNotification(SimCardDataUsageNotificationOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }


        public async Task<SimCardDataUsageNotification> GetSimCardDataUsageNotificationAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public SimCardDataUsageNotification GetSimCardDataUsageNotification(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public SimCardDataUsageNotification DeleteSimCardDataUsageNotification(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<SimCardDataUsageNotification> DeleteSimCardDataUsageNotificationAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<SimCardDataUsageNotification> CreateSimCardDataUsageNotificationAsync(UpsertSIMCardDataUsageNotification options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public SimCardDataUsageNotification CreateSimCardDataUsageNotification(UpsertSIMCardDataUsageNotification options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<SimCardDataUsageNotification> UpdateSimCardDataUsageNotificationAsync(string id, UpsertSIMCardDataUsageNotification options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public SimCardDataUsageNotification UpdateSimCardDataUsageNotification(string id, UpsertSIMCardDataUsageNotification options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }

}
