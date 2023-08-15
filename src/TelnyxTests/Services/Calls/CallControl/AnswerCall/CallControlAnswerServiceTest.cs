// <copyright file="CallControlAnswerServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using TelnyxTests.Infrastructure;
    using Xunit;

    public class CallControlAnswerServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlAnswerService service;
        private readonly CallControlAnswerOptions createOptions;

        public CallControlAnswerServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlAnswerService();

            this.createOptions = new CallControlAnswerOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901")
            };
        }

        [Fact, TestPriority(1)]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }

        [Fact, TestPriority(2)]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CallAnswerResponse", message.GetType().ToString());
        }
    }
}
