namespace TelnyxTests.Services.Calls.ConferenceCommands.NotificationProfile
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Notifications.NotificationProfiles;
    using Xunit;
    using NotificationProfileModel = Telnyx.net.Entities.Notifications.NotificationProfiles.NotificationProfile;

    /// <summary>
    /// Test class for NotificationProfile.
    /// </summary>
    public class NotificationProfileTest : BaseTelnyxTest
    {
        private readonly NotificationProfileService service;
        private readonly NotificationProfileOptions NotificationProfileOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationProfileTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationProfileService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationProfileOptions = new NotificationProfileOptions()
            {
                Name = "Telnyx",
            };
        }

        [Fact]
        public void List()
        {
            var results = this.service.ListNotificationProfiles(this.requestOptions);
            AssertResponse(results);
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var results = await this.service.ListNotificationProfilesAsync(this.requestOptions, cts.Token);
            AssertResponse(results);
        }

        private static void AssertResponse(TelnyxList<NotificationProfileModel> results)
        {
            Assert.NotNull(results);
            Assert.Equal(typeof(TelnyxList<NotificationProfileModel>), results.GetType());
            Assert.Collection(results, result => {
                Assert.Equal("12455643-3cf1-4683-ad23-1cd32f7d5e0a", result.Id);
                Assert.Equal("string", result.Name);
                Assert.NotNull( result.UpdatedAt.ToString());
            });
        }
    }
}
