// <copyright file="JoinConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class JoinConferenceServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly JoinConferenceService service;
        private readonly JoinConferenceOptions createOptions;

        public JoinConferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new JoinConferenceService();

            this.createOptions = new JoinConferenceOptions()
            {
                CallControlId = "AgDIxmoRX6QMuaIj_uXRXnPAXP0QlNfXczRrZvZakpWxBlpw48KyZQ==",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                EndConferenceOnExit = true,
                Hold = true,
                HoldAudioUrl = "AudioURL",
                Mute = false,
                StartConferenceOnEnter = true
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences/{CallControllId}/actions/join");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences/{CallControllId}/actions/join");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }
    }
}
