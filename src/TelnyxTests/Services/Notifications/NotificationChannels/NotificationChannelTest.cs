using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Notifications.NotificationChannels;

using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.Notifications.NotificationChannels;

namespace TelnyxTests.Services.Notifications.Notifications.NotificationChannels

{
    /// <summary>
    /// Test class for NotificationChannel.
    /// </summary>
    public class NotificationChannel : BaseTelnyxTest
    {
        private readonly NotificationChannelService service;
        private readonly NotificationChannelOptions NotificationChannelOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationChannel(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationChannelService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationChannelOptions = new NotificationChannelOptions()
            {
                ChannelDestination = "+13125550000",
                ChannelTypeId = Telnyx.net.Entities.Enum.Notification.NotificationChannels.ChannelType.Voice,
                NotificationProfileId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
            };
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveNotificationChannel(Id, this.NotificationChannelOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationChannel), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNotificationChannelAsync(Id, this.NotificationChannelOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationChannel), result.GetType());
        }
    }
}
