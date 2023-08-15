// <copyright file="CallControlSpeakServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlSpeakServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlSpeakService service;
        private readonly CallControlSpeakOptions createOptions;

        public CallControlSpeakServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlSpeakService();

            this.createOptions = new CallControlSpeakOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Payload = "1www2WABCDw9",
                PayloadType = "text",
                ServiceLevel = "premium",
                Stop = "current",
                Voice = "male",
                Language = "en-US"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/speak");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallSpeakResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/speak");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallSpeakResponse), message.GetType());
        }
    }
}
