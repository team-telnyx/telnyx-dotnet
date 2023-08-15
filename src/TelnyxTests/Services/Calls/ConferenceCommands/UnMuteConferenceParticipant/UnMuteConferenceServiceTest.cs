// <copyright file="UnMuteConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class UnMuteConferenceServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly UnMuteConferenceParticipantService service;
        private readonly MuteConferenceOptions createOptions;

        public UnMuteConferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new UnMuteConferenceParticipantService();

            this.createOptions = new MuteConferenceOptions()
            {
                CallControlIds = new List<string> { "AgDIxmoRX6QMuaIj_uXRXnPAXP0QlNfXczRrZvZakpWxBlpw48KyZQ==" }
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences/{CallControllId}/actions/unmute");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences/{CallControllId}/actions/unmute");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }
    }
}
