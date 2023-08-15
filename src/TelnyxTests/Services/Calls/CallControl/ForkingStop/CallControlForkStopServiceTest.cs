// <copyright file="CallControlForkStopServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class CallControlForkStopServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlForkStopService service;
        private readonly CallControlForkStopOptions createOptions;

        public CallControlForkStopServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlForkStopService();

            this.createOptions = new CallControlForkStopOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/fork_stop");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallForkStopResponse), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/fork_stop");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallForkStopResponse), message.GetType());
        }
    }
}
