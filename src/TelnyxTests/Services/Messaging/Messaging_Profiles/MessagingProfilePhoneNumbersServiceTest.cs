// <copyright file="MessagingProfileServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingProfiles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Xunit;

    public class MessagingProfilePhoneNumbersServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfilePhoneNumberId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
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
            AssertListResponse(messagingPhoneNumber);
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingPhoneNumber = await this.service.ListAsync(MessagingProfilePhoneNumberId);
            AssertListResponse(messagingPhoneNumber);
        }

        [Fact(Skip = "Invalid request error. Corresponding service should be deprecated")]
        public void Get()
        {
            var messagingProfilePhoneNumber = this.service.Get(MessagingProfilePhoneNumberId);
            Assert.NotNull(messagingProfilePhoneNumber);
            Assert.Equal(typeof(MessagingPhoneNumber), messagingProfilePhoneNumber.GetType());
            Assert.NotNull(messagingProfilePhoneNumber.PhoneNumber);
        }

        private static void AssertListResponse(TelnyxList<MessagingPhoneNumber> messagingPhoneNumber)
        {
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
    }
}

