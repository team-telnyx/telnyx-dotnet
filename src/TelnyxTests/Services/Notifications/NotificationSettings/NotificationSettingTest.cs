using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.Notifications.NotificationSettings;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.Notifications;
using System.Net.Mime;
using Telnyx.net.Entities.Notifications.NotificationSettings;
using System;
using System.Collections.Generic;

namespace TelnyxTests.Services.Notifications.Notifications.NotificationSettings

{
    /// <summary>
    /// Test class for NotificationSettingTest.
    /// </summary>
    public class NotificationSettingTest : BaseTelnyxTest
    {
        private readonly NotificationSettingService service;
        private readonly NotificationSettingOptions NotificationSettingOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NotificationSettingTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NotificationSettingService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.NotificationSettingOptions = new NotificationSettingOptions()
            {
                NotificationChannelId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                NotificationEventConditionId = "70c7c5cb-dce2-4124-accb-870d39dbe852",
                NotificationProfileId = "12455643-3cf1-4683-ad23-1cd32f7d5e0a",
                AssociatedRecordType = Telnyx.net.Entities.Enum.Notification.NotificationSettings.AssociatedRecordType.Account,
                NotificationStatus = Telnyx.net.Entities.Enum.Notification.NotificationSettings.NotificationStatus.DeletePending,
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateNotificationSetting(this.NotificationSettingOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateNotificationSettingAsync(this.NotificationSettingOptions, this.requestOptions, cts.Token);
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
            var result = this.service.RetrieveNotificationSetting(Id,this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNotificationSettingAsync(Id, this.baseOptions ,this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NotificationSetting), result.GetType());
        }
    }
}
