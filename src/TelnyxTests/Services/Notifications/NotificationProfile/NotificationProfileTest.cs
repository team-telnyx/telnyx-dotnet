using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Notifications.NotificationProfiles;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.Notifications.NotificationProfiles;

namespace TelnyxTests.Services.Calls.ConferenceCommands.NotificationProfile
{
    /// <summary>
    /// Test class for NotificationProfile.
    /// </summary>
    public class NotificationProfileTest : BaseTelnyxTest
    {
        private readonly NotificationProfileService service;
        private readonly NotificationProfileOptions  NotificationProfileOptions ;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationProfileTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationProfileService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationProfileOptions  = new NotificationProfileOptions ()
            {
                Name = "Telnyx",
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNotificationProfiles(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationProfileOptions), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();    
            var result = await this.service.ListNotificationProfilesAsync(this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationProfileOptions), result.GetType());
        }
    }
}

