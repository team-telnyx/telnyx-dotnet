// <copyright file="CallControlGatherUsingSpeakServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlGatherUsingSpeakServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlGatherUsingSpeakService service;
        private readonly CallControlGatherUsingSpeakOptions createOptions;

        public CallControlGatherUsingSpeakServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlGatherUsingSpeakService();

            this.createOptions = new CallControlGatherUsingSpeakOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Payload = "Say this on the call",
                InvalidPayload = "Say this on the call",
                PayloadType = "text",
                ServiceLevel = "basic",
                Voice = "female",
                Language = "en-US",
                InterDigitTimeoutMillis = 5000,
                MaximumDigits = 128,
                MaximumTries = 3,
                TimeoutMillis = 60000,
                MinimumDigits = 128,
                TerminatingDigit = "#",
                ValidDigits = "123"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/gather_using_speak");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallGatherUsingSpeakResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/gather_using_speak");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallGatherUsingSpeakResponse), message.GetType());
        }
    }
}
