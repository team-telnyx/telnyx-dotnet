// <copyright file="MessagingPhoneNumbersServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingPhoneNumbers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class MessagingPhoneNumbersServiceTest : BaseTelnyxTest
    {
        private const string MessagingPhoneNosId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessagingPhoneNumbersService service;
        private readonly NumberOrderCreateOptions createOptions;
        private readonly MessagingPhoneNumberUpdate updateOptions;
        private readonly MessagingPhoneNumberListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        public MessagingPhoneNumbersServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingPhoneNumbersService();
            this.updateOptions = new MessagingPhoneNumberUpdate
            {
                MessagingProfileId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public void Get()
        {
            var numberOrder = this.service.Get(MessagingPhoneNosId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_phone_numbers/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.MessagingPhoneNumber", numberOrder.GetType().ToString());
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public async Task GetAsync()
        {
            var messagingList = await this.service.GetAsync(MessagingPhoneNosId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_phone_numbers/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingList);
            Assert.Equal("Telnyx.MessagingPhoneNumber", messagingList.GetType().ToString());
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public void List()
        {
            var messagingList = this.service.List(this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_phone_numbers");
            Assert.NotNull(messagingList);
            Assert.Single(messagingList.Data);
            Assert.Equal("Telnyx.MessagingPhoneNumber", messagingList.Data[0].GetType().ToString());
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public async Task ListAsync()
        {
            var numberOrder = await this.service.ListAsync(this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_phone_numbers");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.MessagingPhoneNumber", numberOrder.Data[0].GetType().ToString());
            Assert.Single(numberOrder.Data);
            Assert.Equal("Telnyx.MessagingPhoneNumber", numberOrder.Data[0].GetType().ToString());
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public void Update()
        {
            var numberOrder = this.service.Update(MessagingPhoneNosId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_phone_numbers/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.MessagingPhoneNumber", numberOrder.GetType().ToString());
        }

        [Fact(Skip = "Failing Telynx-Mock Validation valid request")]
        public async Task UpdateAsync()
        {
            var numberOrder = await this.service.UpdateAsync(MessagingPhoneNosId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_phone_numbers/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.MessagingPhoneNumber", numberOrder.GetType().ToString());
        }
    }
}
