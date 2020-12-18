// <copyright file="CreateConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using Xunit;
    using Telnyx.net.Entities;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Calls.CallControlApplications;
    using Telnyx.net.Services.Calls.CallControlApplications;
    using Telnyx.net.Entities.Enum;

    public class CallControlApplicationServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";
        private readonly CallControlApplicationService service;
        private readonly CreateCallControlApplicationOptions createOption;

        public CallControlApplicationServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlApplicationService();
            this.createOption = new CreateCallControlApplicationOptions()
            {
                RecordType = RecordType.CallControlApplication,
                DtmfType = DTMFType.Inband,
                WebhookEventFailoverUrl = "FailureURL",
                WebhookApiVersion = WebhookAPIVersion.V1,
                FirstCommandTimeoutSecs = 10,
                WebhookTimeoutSecs = 12,
                Active = true,
                WebhookEventUrl = "TestURL",
                ApplicationName = "Telnyx"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOption);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
            Assert.NotNull(message.Id);
            Assert.True(message.CreatedAt <= message.UpdatedAt);
            Assert.Equal(this.createOption.DtmfType, message.DtmfType);
            Assert.Equal(this.createOption.RecordType, message.RecordType);
            Assert.Equal(this.createOption.Active, message.Active);
            Assert.Equal(AnchorsiteOverride.Latency, message.AnchorsiteOverride);
            Assert.Equal(this.createOption.ApplicationName, message.ApplicationName);
            Assert.NotNull(message.Inbound);
            Assert.NotNull(message.Inbound.ChannelLimit);
            Assert.NotNull(message.Inbound.SipSubdomain);
            Assert.NotNull(message.Inbound.SipSubdomainReceiveSettings);
            Assert.NotNull(message.Outbound);
            Assert.NotNull(message.Outbound.ChannelLimit);
            Assert.NotNull(message.Outbound.OutboundVoiceProfileId);
            Assert.Equal(this.createOption.FirstCommandTimeout, message.FirstCommandTimeout);
            Assert.Equal(this.createOption.FirstCommandTimeoutSecs, message.FirstCommandTimeoutSecs);
            Assert.Equal(this.createOption.WebhookApiVersion, message.WebhookApiVersion);
            Assert.Equal(this.createOption.WebhookEventFailoverUrl, message.WebhookEventFailoverUrl);
            Assert.Equal(this.createOption.WebhookEventUrl, message.WebhookEventUrl);
            Assert.Equal(this.createOption.WebhookTimeoutSecs, message.WebhookTimeoutSecs);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOption);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.Delete(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteAsync(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public void Get()
        {
            var message = this.service.Get(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var message = await this.service.GetAsync(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public void List()
        {
            var message = this.service.List(new ListCallControlApplicationOptions());
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CallControlApplication>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListAsync(new ListCallControlApplicationOptions());
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CallControlApplication>), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.Update(CallControllId, createOption);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = this.service.UpdateAsync(CallControllId, createOption);
            Assert.NotNull(message);
        }
    }
}

