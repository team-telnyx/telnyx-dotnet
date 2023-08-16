// <copyright file="NumberReservationsServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Numbers.Reservation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class NumberReservationsServiceTest : BaseTelnyxTest
    {
        private const string NumberId = "12ade33a-21c0-473b-b055-b3c836e1c292";

        private readonly NumberReservationsService service;
        private readonly NumberReservation createOptions;
        private readonly NumberReservationsListOptions listOptions;

        public NumberReservationsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberReservationsService();
            this.listOptions = new NumberReservationsListOptions()
            {
                Status = "enabled",
                CreatedAtGt = null,
                CreatedAtLt = null,
                PhoneNumbersPhoneNumber = "9830094821",
                CustomerReference = "Reference001"
            };

            this.createOptions = new NumberReservation
            {
                PhoneNumbers = new List<ReservedPhoneNumber>()
                {
                    new ReservedPhoneNumber
                    {
                        PhoneNumber = "+18665552368"
                    }
                }
            };
        }

        [Fact]
        public void Create()
        {
            var numberReserve = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_reservations");
            Assert.NotNull(numberReserve);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.GetType().ToString());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var numberReserve = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_reservations");
            Assert.NotNull(numberReserve);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.GetType().ToString());
        }

        [Fact]
        public void Get()
        {
            var numberReserve = this.service.Get(NumberId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_reservations/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberReserve);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var numberReserve = await this.service.GetAsync(NumberId);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_reservations/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(numberReserve);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.GetType().ToString());
        }

        [Fact]
        public void List()
        {
            var numberReserve = this.service.List(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_reservations");
            Assert.NotNull(numberReserve);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.Data[0].GetType().ToString());
            Assert.Single(numberReserve.Data);
        }

        [Fact]
        public async Task ListAsync()
        {
            var numberReserve = await this.service.ListAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_reservations");
            Assert.NotNull(numberReserve);
            Assert.Single(numberReserve.Data);
            Assert.Equal("Telnyx.NumberReservation", numberReserve.Data[0].GetType().ToString());
        }
    }
}
