// <copyright file="CallControlDialServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Services.Calls.Models;
    using Xunit;

    public class CallControlDialServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlDialService service;
        private readonly CallControlDialOptions createOptions;

        public CallControlDialServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlDialService();

            this.createOptions = new CallControlDialOptions()
            {
                AnsweringMachineDetection = AnsweringMachineEnum.Disabled,
                AudioUrl = "http://example.com/message.wav",
                ConnectionId = "connection",
                From = "+18005550101",
                LinkTo = "ilditnZK_eVysupV21KzmzN_sM29ygfauQojpm4BgFtfX5hXAcjotg",
                SipAuthPassword = "asfasdfasdf",
                SipAuthUsername = "username@sip.telnyx.com",
                TimeLimitSecs = 100,
                TimeoutSecs = 100,
                To = "+18005550100",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                WebhookUrl = "https://test.com/api/v1/testApi",
                WebhookUrlMethod = WebhookUrlMethods.POST
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallDialResponse), message.GetType());
            Assert.NotNull(message.CallControlId);
            Assert.NotNull(message.CallLegId);
            Assert.NotNull(message.CallSessionId);
            Assert.Equal(RecordType.Call, message.RecordType);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallDialResponse), message.GetType());
            Assert.NotNull(message.CallControlId);
            Assert.NotNull(message.CallLegId);
            Assert.NotNull(message.CallSessionId);
            Assert.Equal(RecordType.Call, message.RecordType);
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.Retrieve(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallDialResponse), message.GetType());
            Assert.NotNull(message.CallControlId);
            Assert.NotNull(message.CallLegId);
            Assert.NotNull(message.CallSessionId);
            Assert.Equal(RecordType.Call, message.RecordType);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveAsync(CallControllId);
            Assert.NotNull(message);
            Assert.Equal(typeof(CallDialResponse), message.GetType());
            Assert.NotNull(message.CallControlId);
            Assert.NotNull(message.CallLegId);
            Assert.NotNull(message.CallSessionId);
            Assert.Equal(RecordType.Call, message.RecordType);
        }
    }
}
