// <copyright file="CallControlPlaybackStartServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlPlaybackStartServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlPlaybackStartService service;
        private readonly CallControlPlaybackStartOptions createOptions;

        public CallControlPlaybackStartServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlPlaybackStartService();

            this.createOptions = new CallControlPlaybackStartOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Loop = "infinity",
                Overlay = false,
                Stop = "current",
                TargetLegs = "self",
                AudioUrl = "http://www.example.com/sounds/greeting.wav"
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/playback_start");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallPlaybackStartResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/playback_start");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallPlaybackStartResponse), message.GetType());
        }
    }
}
