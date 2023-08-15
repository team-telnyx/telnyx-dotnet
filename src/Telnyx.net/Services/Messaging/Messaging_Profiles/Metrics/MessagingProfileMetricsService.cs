namespace Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;

    public class MessagingProfileMetricsService
    {
        private MessagingProfileMetricsOverviewService _overviewService;
        private MessagingProfileMetricsDetailService _detailService;

        public MessagingProfileMetricsService()
        {
            this._overviewService = new MessagingProfileMetricsOverviewService();
            this._detailService = new MessagingProfileMetricsDetailService();
        }

        /// <summary>
        /// ist high-level messaging profile metrics.
        /// </summary>
        /// <param name="options">List Options for pagination and timeframe.</param>
        /// <param name="requestOptions">Request Options (optional).</param>
        /// <param name="ct">Cancellation Token for Async Cancellation (optional).</param>
        /// <returns>List of Highlevel Metrics.</returns>
        public async Task<TelnyxList<MessagingProfileMetricsOverview>> ListHighLevelMetricsAsync(ListMetricsOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._overviewService.ListAsync(options, requestOptions, ct);
        }

        /// <summary>
        /// ist high-level messaging profile metrics.
        /// </summary>
        /// <param name="options">List Options for pagination and timeframe.</param>
        /// <param name="requestOptions">Request Options (optional).</param>
        /// <returns>List of Highlevel Metrics.</returns>
        public TelnyxList<MessagingProfileMetricsOverview> ListHighLevelMetrics(ListMetricsOptions options, RequestOptions requestOptions = null)
        {
            return this._overviewService.List(options, requestOptions);
        }

        /// <summary>
        /// Get detailed messaging metrics for a messaging profile.
        /// </summary>
        /// <param name="messagingProfileId">Messaging ProfileId to Use.</param>
        /// <param name="options">Query string options for timeframe.</param>
        /// <param name="requestOptions">Api Request Options (optional).</param>
        /// <param name="ct"></param>
        /// <returns>Metrics Detail Response.</returns>
        public async Task<MessagingProfileMetricsDetail> GetDetailedMetricsAsync(string messagingProfileId, MetricsOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this._detailService.GetByIdAsync(messagingProfileId, options, requestOptions, ct);
        }

        /// <summary>
        /// Get detailed messaging metrics for a messaging profile.
        /// </summary>
        /// <param name="messagingProfileId">Messaging ProfileId to Use.</param>
        /// <param name="options">Query string options for timeframe.</param>
        /// <param name="requestOptions">Api Request Options (optional).</param>
        /// <returns>Metrics Detail Response.</returns>
        public MessagingProfileMetricsDetail GetDetailedMetrics(string messagingProfileId, MetricsOptions options, RequestOptions requestOptions = null)
        {
            return this._detailService.GetById(messagingProfileId, options, requestOptions);
        }
    }
}
