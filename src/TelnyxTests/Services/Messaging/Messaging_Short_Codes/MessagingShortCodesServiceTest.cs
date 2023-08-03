// <copyright file="MessagingShortCodesServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingShortCodes
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class MessagingShortCodesServiceTest : BaseTelnyxTest
    {
        private const string MessagingShortCodeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessagingShortCodesService service;
        private readonly MessagingShortCodeUpdate updateOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;
        private readonly MessagingShortCodeListOptions listOptions;

        // private readonly NumberOrderCreateOptions createOptions;
        public MessagingShortCodesServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingShortCodesService();

            this.updateOptions = new MessagingShortCodeUpdate
            {
                MessagingProfileId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

            this.listOptions = new MessagingShortCodeListOptions()
            {
                PageToken = null,
                FilterMessagingProfileId = null
            };

            this.requestOptions = new RequestOptions();

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Get()
        {
            var messagingShortCode = this.service.Get(MessagingShortCodeId);
            //this.AssertRequest(HttpMethod.Get, "/v2/short_codes/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingShortCode);
            Assert.Equal("Telnyx.MessagingShortCode", messagingShortCode.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingShortCode = await this.service.GetAsync(MessagingShortCodeId);
            //this.AssertRequest(HttpMethod.Get, "/v2/short_codes/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingShortCode);
            Assert.Equal("Telnyx.MessagingShortCode", messagingShortCode.GetType().ToString());
        }

        [Fact]
        public void List()
        {
            var messagingShortCode = this.service.List(this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/short_codes");
            Assert.NotNull(messagingShortCode);
            Assert.Single(messagingShortCode.Data);
            Assert.Equal("Telnyx.MessagingShortCode", messagingShortCode.Data[0].GetType().ToString());
        }

        [Fact]
        public async Task ListAsync()
        {
            var numberOrder = await this.service.ListAsync(this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/short_codes");
            Assert.NotNull(numberOrder);
            Assert.Single(numberOrder.Data);
            Assert.Equal("Telnyx.MessagingShortCode", numberOrder.Data[0].GetType().ToString());
        }

        [Fact]
        public void Update()
        {
            var numberOrder = this.service.Update(MessagingShortCodeId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/short_codes/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.MessagingShortCode", numberOrder.GetType().ToString());
            Assert.NotNull(numberOrder.Id);
            Assert.NotNull(numberOrder.MessagingProfileId);
            Assert.Equal(this.updateOptions.MessagingProfileId, numberOrder.MessagingProfileId);
            Assert.NotNull(numberOrder.ShortCode);
            Assert.NotNull(numberOrder.CreatedAt);
            Assert.NotNull(numberOrder.UpdatedAt);
            Assert.True(numberOrder.CreatedAt <= numberOrder.UpdatedAt);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.CodeEnum, numberOrder.RecordType);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var messagingShortCode = await this.service.UpdateAsync(MessagingShortCodeId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/short_codes/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingShortCode);
            Assert.Equal("Telnyx.MessagingShortCode", messagingShortCode.GetType().ToString());
        }
    }
}
