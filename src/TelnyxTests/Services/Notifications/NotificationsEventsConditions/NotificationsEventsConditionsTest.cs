using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Notifications.NotificationsEventsConditions;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.Notifications.NotificationsEventsConditions;
using System;
using System.Collections.Generic;

namespace TelnyxTests.Services.Notifications.Notifications.NotificationConditions

{
    /// <summary>
    /// Test class for NotificationsEventsConditionsTest.
    /// </summary>
    public class NotificationsEventsConditionsTest : BaseTelnyxTest
    {
        private readonly NotificationsEventsConditionService service;
        private readonly NotificationsEventsConditionListOptions NotificationsEventsConditionListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationsEventsConditionsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationsEventsConditionService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationsEventsConditionListOptions = new NotificationsEventsConditionListOptions()
            {
                AssociatedRecordType = Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions.AssociatedRecordType.Account,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNotificationsEventsConditions(this.NotificationsEventsConditionListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationsEventsCondition), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNotificationsEventsConditionsAsync(this.NotificationsEventsConditionListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationsEventsCondition), result.GetType());
        }
    }
}
