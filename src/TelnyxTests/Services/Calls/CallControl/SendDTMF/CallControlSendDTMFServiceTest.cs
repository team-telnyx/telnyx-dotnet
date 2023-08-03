// <copyright file="CallControlSendDTMFServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlSendDTMFServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlSendDTMFService service;
        private readonly CallControlSendDTMFOptions createOptions;

        public CallControlSendDTMFServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlSendDTMFService();

            this.createOptions = new CallControlSendDTMFOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Digits = "1www2WABCDw9",
                DurationMillis = 250
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/send_dtmf");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallSendDTMFResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/send_dtmf");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallSendDTMFResponse), message.GetType());
        }
    }
}
