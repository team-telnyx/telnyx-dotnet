﻿// <copyright file="CallControlBridgeServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.CallCommands
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Telnyx;
    using TelnyxTests.Infrastructure;
    using Xunit;

    public class CallControlBridgeServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlBridgeService service;
        private readonly CallControlBridgeOptions createOptions;

        public CallControlBridgeServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlBridgeService();

            this.createOptions = new CallControlBridgeOptions()
            {
                CallControlId = new System.Guid("c8ac9611-25c3-494a-b8b4-2f036a18a6b2"),
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                ParkAfterUnbridge = "self"
            };
        }

        [Fact, TestPriority(1)]
        public void Create()
        {
            var message = this.service.Create(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/bridge");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallBridgeResponse), message.GetType());
        }

        [Fact, TestPriority(2)]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(CallControllId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/bridge");
            Assert.NotNull(message);
            Assert.Equal(typeof(CallBridgeResponse), message.GetType());    

        }
    }
}