// <copyright file="CallControlPlaybackStopServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlPlaybackStopServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlPlaybackStopService service;
        private readonly CallControlPlaybackStopOptions createOptions;

        public CallControlPlaybackStopServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlPlaybackStopService();

            this.createOptions = new CallControlPlaybackStopOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Stop = "all"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/playback_stop");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallPlaybackStopResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/playback_stop");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallPlaybackStopResponse), message.GetType());
        }
    }
}
