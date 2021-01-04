// <copyright file="MessagingProfileServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingProfiles
{
    using System.Threading.Tasks;
    using System.Linq;
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
            Assert.True(messagingPhoneNumber.Data.Count > 0);
            var messagingProfile = messagingPhoneNumber.Data.FirstOrDefault();
            Assert.NotNull(messagingProfile);
            Assert.NotNull(messagingProfile.Id);
            Assert.True(messagingProfile.CreatedAt <= messagingProfile.UpdatedAt);
            Assert.NotNull(messagingProfile.CountryCode);
            Assert.NotNull(messagingProfile.MessagingProfileId);
            Assert.NotNull(messagingProfile.MessagingProduct);
            Assert.NotNull(messagingProfile.PhoneNumber);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.MessagingSettings, messagingProfile.RecordType);
            Assert.NotNull(messagingProfile.TrafficType);
            Assert.NotNull(messagingProfile.Type);
            Assert.NotNull(messagingProfile.Health);
            Assert.True(messagingProfile.Health.InboundOutboundRatio >= 0);
            Assert.True(messagingProfile.Health.MessageCount >= 0);
            Assert.True(messagingProfile.Health.SpamRatio >= 0);
            Assert.True(messagingProfile.Health.SuccessRatio >= 0);
            Assert.NotNull(messagingProfile.EligibleMessagingProducts);
            Assert.False(messagingProfile.EligibleMessagingProducts.Where(x => x == null).Any());
            Assert.NotNull(messagingProfile.Features);
            Assert.NotNull(messagingProfile.Features.Sms);
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingPhoneNumber = await this.service.ListAsync(MessagingProfilePhoneNumberId);
            Assert.NotNull(messagingPhoneNumber);
            Assert.Equal(typeof(TelnyxList<MessagingPhoneNumber>), messagingPhoneNumber.GetType());
        }

        [Fact(Skip = "Invalid request error. Corresponding service should be deprecated")]
        public void Get()
        {
            var messagingProfilePhoneNumber = this.service.Get(MessagingProfilePhoneNumberId);
            Assert.NotNull(messagingProfilePhoneNumber);
            Assert.Equal(typeof(MessagingPhoneNumber), messagingProfilePhoneNumber.GetType());
            Assert.NotNull(messagingProfilePhoneNumber.PhoneNumber);
        }
    }
}

