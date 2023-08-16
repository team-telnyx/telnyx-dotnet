namespace Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;

    internal class MessagingProfileMetricsOverviewService : Service<MessagingProfileMetricsOverview>
    {
        public override string BasePath => "/messaging_profile_metrics";

        public TelnyxList<MessagingProfileMetricsOverview> List(ListMetricsOptions options, RequestOptions reqOps = null)
        {
            return this.ListEntities(options, reqOps);
        }

        public async Task<TelnyxList<MessagingProfileMetricsOverview>> ListAsync(ListMetricsOptions options, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOps, string.Empty, ct);
        }
    }
}
