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

    public class CallControlApplicationServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";
        private readonly CallControlApplicationService service;
        private readonly CreateCallControlApplicationOptions option;

        public CallControlApplicationServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlApplicationService();
            this.option = new CreateCallControlApplicationOptions()
            {
                Active = true,
                WebhookEventUrl = "TestURL",
                ApplicationName = "Telnyx"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.option);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.option);
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
            var message = this.service.List();
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CallControlApplication>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListAsync();
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CallControlApplication>), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.Update(CallControllId, option);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallControlApplication), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = this.service.UpdateAsync(CallControllId, option);
            Assert.NotNull(message);
        }
    }
}

