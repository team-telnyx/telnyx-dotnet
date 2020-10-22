﻿using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics;
using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;
using Xunit;

namespace TelnyxTests.Services.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsOverviewServiceTest : BaseTelnyxTest
    {
        private readonly MessagingProfileMetricsOverviewService service;
        private readonly ListMetricsOptions listMetricsOptions;

        public MessagingProfileMetricsOverviewServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            listMetricsOptions = null;
            service = new MessagingProfileMetricsOverviewService();
        }

        [Fact]
        public void List()
        {
            var messagingProfileMetrics = this.service.List(listMetricsOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(TelnyxList<MessagingProfileMetricsOverview>), messagingProfileMetrics.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingProfileMetrics = await this.service.ListAsync(listMetricsOptions);
            Assert.NotNull(messagingProfileMetrics);
            Assert.Equal(typeof(TelnyxList<MessagingProfileMetricsOverview>), messagingProfileMetrics.GetType());
        }
    }
}

