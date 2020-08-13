using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;

namespace Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics
{
    internal class MessagingProfileMetricsDetailService : Service<MessagingProfileMetricsDetailResponse>
    {
        public override string BasePath => "/messaging_profiles";

        public override string PostPath => "metrics";

        public async Task<MessagingProfileMetricsDetailResponse> GetByIdAsync(string id, MetricsOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, requestOptions, ct, postPath: PostPath);
        }

        public MessagingProfileMetricsDetailResponse GetById(string id, MetricsOptions options, RequestOptions requestOptions)
        {
            return this.GetEntity(id, options, requestOptions, postPath: PostPath);
        }
    }
}
