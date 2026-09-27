namespace TelnyxTests.Services.Notifications.Notifications.NotificationConditions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.NotificationsEventsConditions;
    using Telnyx.net.Services.Notifications.NotificationsEventsConditions;
    using Xunit;

    /// <summary>
    /// Test class for NotificationsEventsConditionsTest.
    /// </summary>
    public class NotificationsEventsConditionsTest : BaseTelnyxTest
    {
        private readonly NotificationsEventsConditionService service;
        private readonly NotificationsEventsConditionListOptions notificationsEventsConditionListOptions;
        private readonly RequestOptions requestOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsEventsConditionsTest"/> class.
        /// </summary>
        /// <param name="mockHttpClientFixture">mock fixture.</param>
        public NotificationsEventsConditionsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationsEventsConditionService();
            this.requestOptions = new RequestOptions();
            this.notificationsEventsConditionListOptions = new NotificationsEventsConditionListOptions()
            {
                AssociatedRecordType = Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions.AssociatedRecordType.Account,
            };
        }

        [Theory]
        [InlineData(Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions.AssociatedRecordType.Account, "account")]
        [InlineData(Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions.AssociatedRecordType.PhoneNumber, "phone_number")]
        public void AssociatedRecordTypeUsesDocumentedWireValue(
            Telnyx.net.Entities.Enum.Notification.NotificationsEventsConditions.AssociatedRecordType value, string expected)
        {
            var url = "/notification_event_conditions";
            Telnyx.Infrastructure.Middleware.RequestStringBuilder.CreateQuery(ref url,
                new NotificationsEventsConditionListOptions { AssociatedRecordType = value, ExtraParams = null, Expand = null });
            Assert.Equal("/notification_event_conditions?filter[associated_record_type][eq]=" + expected + "&", url);
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNotificationsEventsConditions(this.notificationsEventsConditionListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NotificationsEventsCondition>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNotificationsEventsConditionsAsync(this.notificationsEventsConditionListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NotificationsEventsCondition>), result.GetType());
        }
    }
}
