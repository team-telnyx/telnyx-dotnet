// <copyright file="CallControlTransferServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services.Calls.Models;
    using Xunit;

    public class CallControlTransferServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlTransferService service;
        private readonly CallControlTransferOptions createOptions;

        public CallControlTransferServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlTransferService();

            this.createOptions = new CallControlTransferOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                To = "SIP:username@sip.telnyx.com",
                From = "+18005550101",
                AudioUrl = "http://www.example.com/sounds/greeting.wav",
                TimeLimitSecs = 14400,
                TimeoutSecs = 30,
                AnsweringMachineDetection = AnsweringMachineEnum.Disabled,
                SipAuthPassword = "username@sip.telnyx.com",
                SipAuthUsername = "username@sip.telnyx.com"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/transfer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallTransferResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/transfer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallTransferResponse), message.GetType());
        }
    }
}
