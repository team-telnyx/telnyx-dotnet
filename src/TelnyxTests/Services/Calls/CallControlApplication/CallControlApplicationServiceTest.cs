// <copyright file="CreateConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Calls.CallControlApplications;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Services.Calls.CallControlApplications;
    using Xunit;

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
                WebhookEventFailoverUrl = "https://www.failure.com",
                WebhookApiVersion = WebhookAPIVersion.V1,
                FirstCommandTimeoutSecs = 10,
                WebhookTimeoutSecs = 12,
                Active = true,
                WebhookEventUrl = "https://www.test.com",
                ApplicationName = "Telnyx"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOption);
            AssertCreate(message);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOption);
            AssertCreate(message);
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
            var message = this.service.Update(CallControllId, this.createOption);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateAsync(CallControllId, this.createOption);
            Assert.NotNull(message);
        }

        private static void AssertCreate(CallControlApplication message)
        {
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
            Assert.Equal("1293384261075731499", message.Id);
            Assert.True(message.CreatedAt <= message.UpdatedAt);
            Assert.Equal(DTMFType.Inband, message.DtmfType);
            Assert.Equal(RecordType.CallControlApplication, message.RecordType);
            Assert.False(message.Active);
            Assert.Equal(AnchorsiteOverride.Latency, message.AnchorsiteOverride);
            Assert.Equal("call-router", message.ApplicationName);
            Assert.NotNull(message.Inbound);
            Assert.Equal(10, message.Inbound.ChannelLimit);
            Assert.Equal("example", message.Inbound.SipSubdomain);
            Assert.Equal(Telnyx.net.Entities.Calls.CallControlApplications.SipSubdomainReceiveSettings.OnlyMyConnections, message.Inbound.SipSubdomainReceiveSettings);
            Assert.NotNull(message.Outbound);
            Assert.Equal(10, message.Outbound.ChannelLimit);
            Assert.Equal("1293384261075731499", message.Outbound.OutboundVoiceProfileId);
            Assert.True(message.FirstCommandTimeout);
            Assert.Equal(10, message.FirstCommandTimeoutSecs);
            Assert.Equal(WebhookAPIVersion.V1, message.WebhookApiVersion);
            Assert.Equal("https://failover.example.com", message.WebhookEventFailoverUrl);
            Assert.Equal("https://example.com", message.WebhookEventUrl);
            Assert.Equal(25, message.WebhookTimeoutSecs);
        }
    }
}

