// <copyright file="CallControlGatherTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlGatherTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlGatherService service;
        private readonly CallControlGatherOptions createOptions;

        public CallControlGatherTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlGatherService();

            this.createOptions = new CallControlGatherOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                InterDigitTimeoutMillis = 5000,
                TimeoutMillis = 60000,
                ValidDigits = "123",
                TerminatingDigit = "#",
                MaximumDigits = 10,
                MinimumDigits = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/gather");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallGatherUsingAudioResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/gather");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallGatherUsingAudioResponse), message.GetType());
        }
    }
}
