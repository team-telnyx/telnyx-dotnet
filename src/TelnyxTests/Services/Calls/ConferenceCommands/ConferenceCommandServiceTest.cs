// <copyright file="UnMuteConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class ConferenceCommandServiceTest : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly ConferenceCommandsService service;
        private readonly CreateConferenceOptions createOptions;

        public ConferenceCommandServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConferenceCommandsService();
            this.createOptions = new CreateConferenceOptions()
            {
                BeepEnabled = CreateConferenceOptions.BeepEnum.NEVER,
                DurationMinutes = 01,
                CallControlId = "001",
                HoldAudioUrl = "HoldAudioURL",
                ClientState = "State1",
                CommandId = Guid.NewGuid(),
                Name = "Name",
                StartConferenceOnCreate = true
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOptions);
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CreateConferenceResponse", message.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(message);
            Assert.Equal("Telnyx.CreateConferenceResponse", message.GetType().ToString());
        }
    }
}

