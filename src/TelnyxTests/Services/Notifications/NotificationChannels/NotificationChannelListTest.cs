namespace TelnyxTests.Services.Calls.ConferenceCommands.NotificationChannelList
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Enum.Notification.NotificationChannels;
    using Telnyx.net.Entities.Notifications.NotificationChannels;
    using Telnyx.net.Services.Notifications.NotificationChannels;
    using Xunit;

    /// <summary>
    /// Test class for NotificationChannelList.
    /// </summary>
    public class NotificationChannelListTest : BaseTelnyxTest
    {
        private readonly NotificationChannelService service;
        private readonly NotificationChannelListOptions NotificationChannelListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationChannelListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationChannelService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationChannelListOptions = new NotificationChannelListOptions()
            {
                TtlSeconds = Telnyx.net.Entities.Enum.Notification.NotificationChannels.ChannelType.Voice,
            };
        }

        [Fact]
        public void List()
        {
            var results = this.service.ListNotificationChannels(this.NotificationChannelListOptions, this.requestOptions);
            AssertResponse(results);
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var results = await this.service.ListNotificationChannelsAsync(this.NotificationChannelListOptions, this.requestOptions, cts.Token);
            AssertResponse(results);
        }

        private static void AssertResponse(TelnyxList<NotificationChannel> results)
        {
            Assert.NotNull(results);
            Assert.Equal(typeof(TelnyxList<NotificationChannel>), results.GetType());
            Assert.Collection(results, result => {
                Assert.Equal(typeof(NotificationChannel), result.GetType());
                Assert.Equal("+13125550000", result.ChannelDestination);
                Assert.Equal(ChannelType.SMS, result.ChannelTypeId);
                Assert.Equal("12455643-3cf1-4683-ad23-1cd32f7d5e0a", result.Id);
                Assert.Equal("12455643-3cf1-4683-ad23-1cd32f7d5e0a", result.NotificationProfileId);
                Assert.Equal("10/15/2019 10:07:15", result.UpdatedAt);
            });
        }
    }
}
