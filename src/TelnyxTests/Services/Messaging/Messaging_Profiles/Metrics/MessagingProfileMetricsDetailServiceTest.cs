namespace TelnyxTests.Services.Messaging.Messaging_Profiles.Metrics
{
    using System.Linq;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;
    using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;
    using Xunit;

    public class MessagingProfileMetricsDetailServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfileMetricsDetailId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingProfileMetricsDetailService service;
        private readonly MetricsOptions metricsOptions;
        private readonly RequestOptions requestOptions;

        public MessagingProfileMetricsDetailServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.metricsOptions = null;
            this.requestOptions = null;
            this.service = new MessagingProfileMetricsDetailService();
        }

        [Fact]
        public void Get()
        {
            var messagingProfileMetrics = this.service.GetById(MessagingProfileMetricsDetailId, this.metricsOptions, this.requestOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
            Assert.NotNull(messagingProfileMetrics.Overview);
            Assert.NotNull(messagingProfileMetrics.Overview.Inbound);
            Assert.True(messagingProfileMetrics.Overview.Inbound.Received >= 0);
            Assert.NotNull(messagingProfileMetrics.Overview.Outbound);
            Assert.True(messagingProfileMetrics.Overview.Outbound.Delivered >= 0);
            Assert.True(messagingProfileMetrics.Overview.Outbound.Errors >= 0);
            Assert.True(messagingProfileMetrics.Overview.Outbound.Sent >= 0);
            Assert.NotNull(messagingProfileMetrics.Overview.MessagingProfileId);
            Assert.True(messagingProfileMetrics.Overview.PhoneNumbers >= 0);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.MessagingProfileMetrics, messagingProfileMetrics.Overview.RecordType);
            Assert.NotNull(messagingProfileMetrics.Overview.Outbound);
            Assert.NotNull(messagingProfileMetrics.Detailed);
            Assert.True(messagingProfileMetrics.Detailed.Count() >= 0);
            var detailData = messagingProfileMetrics.Detailed.First();
            Assert.NotNull(detailData.Metrics);
            var detailMetrics = detailData.Metrics.FirstOrDefault();
            Assert.NotNull(detailMetrics);
            Assert.True(detailMetrics.Delivered >= 0);
            Assert.True(detailMetrics.Errors >= 0);
            Assert.NotNull(detailMetrics.Label);
            Assert.True(detailMetrics.Received >= 0);
            Assert.True(detailMetrics.Sent >= 0);
            Assert.NotNull(detailData.TimeStamp);
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingProfileMetrics = await this.service.GetByIdAsync(MessagingProfileMetricsDetailId, this.metricsOptions, this.requestOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
        }
    }
}

