using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;

namespace Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics
{
    internal class MessagingProfileMetricsDetailService : Service<MessagingProfileMetricsDetail>
    {
        public override string BasePath => "/messaging_profiles";

        public override string PostPath => "metrics";

        public async Task<MessagingProfileMetricsDetail> GetByIdAsync(string id, MetricsOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, requestOptions, ct, postPath: PostPath);
        }

        public MessagingProfileMetricsDetail GetById(string id, RequestOptions requestOptions)
        {
            return this.GetEntity(id, null, requestOptions, postPath: PostPath);
        }
    }
}
