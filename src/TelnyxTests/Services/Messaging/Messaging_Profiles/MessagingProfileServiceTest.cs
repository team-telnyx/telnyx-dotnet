// <copyright file="MessagingProfileServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingProfiles
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class MessagingProfileServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfileId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessagingProfileService service;
        private readonly MessagingProfilePhoneNumbersService phoneNumbersService;
        private readonly NewMessagingProfile createOptions;
        private readonly MessagingProfileUpdate updateOptions;
        private readonly ListMessagingProfilesPhoneNumbersOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        public MessagingProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingProfileService();
            this.phoneNumbersService = new MessagingProfilePhoneNumbersService();

            this.createOptions = new NewMessagingProfile
            {
                Name = "Summer Campaign"
            };
            this.updateOptions = new MessagingProfileUpdate
            {
                Name = "Summer Campaign"
            };
            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Create()
        {
            var messagingProfile = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var messagingProfile = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Delete, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Delete, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(deleted);
        }

        [Fact]
        public void Get()
        {
            var messagingProfile = this.service.Get(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingProfile = await this.service.GetAsync(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public void List()
        {
            var messagingProfile = this.service.List(this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Single(messagingProfile.Data);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.Data[0].GetType().ToString());
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingProfile = await this.service.ListAsync(this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.Data[0].GetType().ToString());
            Assert.Single(messagingProfile.Data);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.Data[0].GetType().ToString());
        }

        [Fact]
        public void Update()
        {
            var messagingProfile = this.service.Update(MessagingProfileId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var messagingProfile = await this.service.UpdateAsync(MessagingProfileId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal("Telnyx.MessagingProfile", messagingProfile.GetType().ToString());
        }

        [Fact]
        public void ListAllPhoneNumbers()
        {
            var messagingPhoneNumber = this.phoneNumbersService.List(MessagingProfileId, this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6/phone_numbers");
            Assert.NotNull(messagingPhoneNumber);
            Assert.NotNull(messagingPhoneNumber.Data[0]);
            Assert.Equal("Telnyx.MessagingPhoneNumber", messagingPhoneNumber.Data[0].GetType().ToString());
        }

        [Fact]
        public async Task ListAllPhoneNumbersAsync()
        {
            var messagingPhoneNumber = await this.phoneNumbersService.ListAsync(MessagingProfileId, this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6/phone_numbers");
            Assert.NotNull(messagingPhoneNumber);
            Assert.NotNull(messagingPhoneNumber.Data[0]);
            Assert.Equal("Telnyx.MessagingPhoneNumber", messagingPhoneNumber.Data[0].GetType().ToString());
        }
    }
}
