// <copyright file="CreateConferenceServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Calls.ConfrenceCommands
{
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Enum;
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
                BeepEnabled = CreateConferenceOptions.BeepEnum.ON_ENTER,
                DurationMinutes = 01,
                HoldAudioUrl = "AudioURL",
                CallControlId = "AgDIxmoRX6QMuaIj_uXRXnPAXP0QlNfXczRrZvZakpWxBlpw48KyZQ==",
                Name = "Business",
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                StartConferenceOnCreate = true,
            };
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOptions);
            AssertResponse(message);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOptions);
            AssertResponse(message);
        }

        private static void AssertResponse(CreateConferenceResponse message)
        {
            Assert.NotNull(message);
            Assert.Equal(typeof(CreateConferenceResponse), message.GetType());
            Assert.Equal("All hands meeting", message.Name);
            Assert.NotNull(message.CreatedAt.ToString());
            Assert.NotNull(message.ExpiresAt.ToString());
            Assert.Equal(RecordType.Conference, message.RecordType);
            Assert.Equal("3fa85f64-5717-4562-b3fc-2c963f66afa6", message.Id.ToString());
        }
    }
}
