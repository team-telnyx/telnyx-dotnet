// <copyright file="NumberOrderServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Numbers.Order
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class NumberOrderServiceTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";
        private const string PhoneNumber = "+13127000090";

        private readonly NumberOrderService service;
        private readonly NumberOrderCreateOptions createOptions;
        private readonly NumberOrderUpdateOptions updateOptions;
        private readonly NumberOrderListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        private List<PhoneNumber> phoneNumbers;

        public NumberOrderServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberOrderService();

            this.createOptions = new NumberOrderCreateOptions()
            {
                Id = Guid.NewGuid(),
                RecordType = Telnyx.net.Entities.Enum.RecordType.Address,
                PhoneNumbersCount = 12,
                Status = NumberOrderCreateOptions.StatusEnum.PendingEnum,
                CustomerReference = "Test",
                ConnectionId = "Id001",
                MessagingProfileId = Guid.NewGuid(),
                WebhookUrl = "TestUrl",
                WebhookFailoverUrl = "FailureUrl",
                CreatedAt = null,
                UpdatedAt = null,
                RequirementsMet = true,
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber { Phone_Number = "+13127000090" }
                }
            };

            this.listOptions = new NumberOrderListOptions()
            {
                Status = "enabled",
                CreatedAtGt = null,
                CreatedAtLt = null,
                PhoneNumbersPhoneNumber = "9089983721",
                CustomerReference = "Test",
                RequirementsMet = true
            };

            this.updateOptions = new NumberOrderUpdateOptions
            {
                NumberOrderId = NumberOrderId,
                Body = new NumberOrder
                {
                    CustomerReference = "MY REF"
                }
            };

            this.requestOptions = new RequestOptions();

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Create()
        {
            var numberOrder = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var numberOrder = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.GetType().ToString());
        }

        [Fact]
        public void Get()
        {
            var numberOrder = this.service.Get(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberOrder);
            Assert.IsType<NumberOrder>(numberOrder);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var numberOrder = await this.service.GetAsync(NumberOrderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.GetType().ToString());
        }

        [Fact]
        public void List()
        {
            var numberOrder = this.service.List(this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Single(numberOrder.Data);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.Data[0].GetType().ToString());
        }

        [Fact]
        public async Task ListAsync()
        {
            var numberOrder = await this.service.ListAsync(this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(numberOrder);
            Assert.Single(numberOrder.Data);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.Data[0].GetType().ToString());
        }

        [Fact]
        public void Update()
        {
            NumberOrder response = this.service.Update(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(response);
            Assert.Equal("Telnyx.NumberOrder", response.GetType().ToString());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var numberOrder = await this.service.UpdateAsync(NumberOrderId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/number_orders/" + NumberOrderId);
            Assert.NotNull(numberOrder);
            Assert.Equal("Telnyx.NumberOrder", numberOrder.GetType().ToString());
        }
    }
}
