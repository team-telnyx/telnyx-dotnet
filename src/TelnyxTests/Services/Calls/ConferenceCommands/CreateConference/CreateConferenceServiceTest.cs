// <copyright file="CreateConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CreateConferenceServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly ConferenceCommandsService service;
        private readonly CreateConferenceOptions createOptions;

        public CreateConferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConferenceCommandsService();

            this.createOptions = new CreateConferenceOptions()
            {
                CallControlId = "AgDIxmoRX6QMuaIj_uXRXnPAXP0QlNfXczRrZvZakpWxBlpw48KyZQ==",
                Name = "Business",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901")
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.ConferenceResponse", message.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/conferences");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.ConferenceResponse", message.GetType().ToString());
        }
    }
}
