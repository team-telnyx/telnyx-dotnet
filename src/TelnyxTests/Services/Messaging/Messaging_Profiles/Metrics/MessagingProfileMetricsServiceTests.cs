namespace TelnyxTests.Services.Messaging.Messaging_Profiles.Metrics
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;
    using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;
    using Xunit;

    public class MessagingProfileMetricsServiceTests : BaseTelnyxTest
    {
        private const string MessagingProfileId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingProfileMetricsService service;
        private ListMetricsOptions listOptions;
        private MetricsOptions getOptions;

        public MessagingProfileMetricsServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingProfileMetricsService();
            this.listOptions = null; //null due to mock not allowing params
            this.getOptions = null; //null due to mock not allowing params
        }

        [Fact]
        public void Get()
        {
            var messagingProfileMetrics = this.service.GetDetailedMetrics(MessagingProfileId, this.getOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingProfileMetrics = await this.service.GetDetailedMetricsAsync(MessagingProfileId, this.getOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsDetail), messagingProfileMetrics.GetType());
        }

        [Fact]
        public void List()
        {
            var messagingProfileMetrics = this.service.ListHighLevelMetrics(this.listOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Single(messagingProfileMetrics.Data);
            Assert.Equal(typeof(MessagingProfileMetricsOverview), messagingProfileMetrics.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingProfileMetrics = await this.service.ListHighLevelMetricsAsync(this.listOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(MessagingProfileMetricsOverview), messagingProfileMetrics.Data[0].GetType());
            Assert.Single(messagingProfileMetrics.Data);
        }
    }
}
