namespace TelnyxTests.Services.Notifications.Notifications.NotificationSettings
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Notifications.NotificationSettings;
    using Telnyx.net.Services.Notifications.NotificationSettings;
    using Xunit;

    /// <summary>
    /// Test class for NotificationSettingTest.
    /// </summary>
    public class NotificationSettingTest : BaseTelnyxTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly NotificationSettingService service;
        private readonly NotificationSettingOptions notificationSettingOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationSettingTest"/> class.
        /// </summary>
        /// <param name="mockHttpClientFixture">mock fixture.</param>
        public NotificationSettingTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationSettingService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.notificationSettingOptions = new NotificationSettingOptions()
            {
                NotificationChannelId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                NotificationEventConditionId = "70c7c5cb-dce2-4124-accb-870d39dbe852",
                NotificationProfileId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                Parameters = { },
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateNotificationSetting(this.notificationSettingOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateNotificationSettingAsync(this.notificationSettingOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.NotificationSettingDelete(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public async Task DeleteSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteNotificationSettingAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveNotificationSetting(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNotificationSettingAsync(Id, this.baseOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }
    }
}
