using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Notifications.NotificationChannels;

using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.Notifications.NotificationChannels;

namespace TelnyxTests.Services.Calls.ConferenceCommands.NotificationChannelList
{
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
            var result = this.service.ListNotificationChannels(this.NotificationChannelListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationChannelListOptions), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNotificationChannelsAsync( this.NotificationChannelListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationChannelListOptions), result.GetType());
        }
    }
}

