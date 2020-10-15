using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;
using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;
using Xunit;

namespace TelnyxTests.Services.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsDetailServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfileMetricsDetailId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingProfileMetricsDetailService service;
        private readonly MetricsOptions metricsOptions;
        private readonly RequestOptions requestOptions;

        public MessagingProfileMetricsDetailServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            metricsOptions = null;
            requestOptions = null;
            service = new MessagingProfileMetricsDetailService();
        }

        [Fact]
        public void Get()
        {
            var messagingProfileMetrics = this.service.GetById(MessagingProfileMetricsDetailId, metricsOptions, requestOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingProfileMetrics = await this.service.GetByIdAsync(MessagingProfileMetricsDetailId, metricsOptions, requestOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
        }
    }
}

