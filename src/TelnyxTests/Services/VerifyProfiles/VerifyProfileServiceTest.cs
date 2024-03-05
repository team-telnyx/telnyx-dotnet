using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VerifyProfiles;
using Telnyx.net.Services.VerifyProfiles;
using Xunit;

namespace TelnyxTests.Services.VerifyProfiles
{
    public class VerifyProfileServiceTest : BaseTelnyxTest
    {
        private readonly VerifyProfileService service;
        private readonly VerifyProfileOption listOptions;
        private readonly UpsertVerifyProfile createOptions;
        private readonly RequestOptions requestOptions;
        private readonly string credConnId = "1234";
        private const string Id = "12ade33a-21c0-473b-b055-b3c836e1c292";

        public VerifyProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new VerifyProfileService();

            this.listOptions = new VerifyProfileOption()
            {
            };
            this.createOptions = new UpsertVerifyProfile()
            {
               Name = "Test Profile",
               WebhookUrl = "http://example.com/webhook",
                WebhookFailoverUrl = "http://example.com/webhook/failover",
                Sms = new SmsSettings()
                { 
                    DefaultVerificationTimeoutSecs = 300, 
                    MessagingTemplate = "Hello, this is the Acme Inc verification code you requested: {code}.",
                    MessagingEnabled = true,
                    RcsEnabled = true,
                    VsmsEnabled = true
                },

                Psd2 = new Psd2Settings()
                {
                    DefaultVerificationTimeoutSecs = 300
                },

                Whatsapp = new WhatsappSettings()
                {
                    DefaultVerificationTimeoutSecs = 300,
                    AppName = "Example Secure App"
                },

                Call = new CallSettings()
                {
                    MessagingTemplate = "Hello, this is the Acme Inc verification code you requested: {code}.",
                    DefaultVerificationTimeoutSecs = 300,
                    DefaultCallTimeoutSecs = 300,
                },

                Flashcall = new FlashcallSettings()
                {
                    DefaultVerificationTimeoutSecs = 300
                },

                Language = "en-US"
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListVerifyProfile(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VerifyProfile>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListVerifyProfileAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VerifyProfile>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetVerifyProfile(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetVerifyProfileAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateVerifyProfile(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateVerifyProfileAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(VerifyProfile), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteVerifyProfile(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteVerifyProfileAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateVerifyProfile(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateVerifyProfileAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifyProfile), message.GetType());
        }
    }
}
