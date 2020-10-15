// <copyright file="MessagingProfileServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingProfiles
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Xunit;

    public class MessagingProfilePhoneNumbersServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfilePhoneNumberId = "1";
        private readonly MessagingProfilePhoneNumbersService service;

        public MessagingProfilePhoneNumbersServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingProfilePhoneNumbersService();
        }


        [Fact]
        public void List()
        {
            var messagingPhoneNumber = this.service.List(MessagingProfilePhoneNumberId);
            Assert.NotNull(messagingPhoneNumber);
            Assert.Equal(typeof(TelnyxList<MessagingPhoneNumber>), messagingPhoneNumber.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingPhoneNumber = await this.service.ListAsync(MessagingProfilePhoneNumberId);
            Assert.NotNull(messagingPhoneNumber);
            Assert.Equal(typeof(TelnyxList<MessagingPhoneNumber>), messagingPhoneNumber.GetType());
        }
    }
}

