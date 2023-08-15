namespace TelnyxTests.Services.Notifications.Notifications.NotificationSettings

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.NotificationSettings;
    using Telnyx.net.Services.Notifications.NotificationSettings;
    using Xunit;

    /// <summary>
    /// Test class for NotificationSettingListTest.
    /// </summary>
    public class NotificationSettingListTest : BaseTelnyxTest
    {
        private readonly NotificationSettingService service;
        private readonly NotificationSettingListOptions NotificationSettingListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationSettingListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationSettingService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationSettingListOptions = new NotificationSettingListOptions()
            {
                NotificationChannelId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                NotificationEventConditionId = "70c7c5cb-dce2-4124-accb-870d39dbe852",
                NotificationProfileId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                AssociatedRecordType = Telnyx.net.Entities.Enum.Notification.NotificationSettings.AssociatedRecordType.Account,
                NotificationStatus = Telnyx.net.Entities.Enum.Notification.NotificationSettings.NotificationStatus.DeletePending,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNotificationSettings(this.NotificationSettingListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NotificationSetting>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNotificationSettingsAsync(this.NotificationSettingListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NotificationSetting>), result.GetType());
        }
    }
}
