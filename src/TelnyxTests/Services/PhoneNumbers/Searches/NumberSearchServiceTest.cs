// <copyright file="NumberSearchServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Numbers.Search
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    public class NumberSearchServiceTest : BaseTelnyxTest
    {
        private readonly NumberSearchService numberSearchService;
        private readonly NumberSearchOptions listOptions;

        public NumberSearchServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.numberSearchService = new NumberSearchService();
            this.listOptions = new NumberSearchOptions()
            {
                StartsWith = "A",
                EndsWith = "D",
                Contains = "Ax",
                Locality = "Test",
                AdministrativeArea = "Test",
                RateCenter = "Test",
                NumberType = null,
                BestEffort = true,
                Quickship = false,
                Limit = 12
            };
        }

        [Fact]
        public void List()
        {
            var numberSearch = this.numberSearchService.List(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/available_phone_numbers");
            Assert.NotNull(numberSearch);
            Assert.Equal("Telnyx.AvailablePhoneNumber", numberSearch.Data[0].GetType().ToString());
            Assert.Single(numberSearch.Data);
        }

        [Fact]
        public void ListWithOptions()
        {
            var numberSearch = this.numberSearchService.List(new NumberSearchOptions { CountryCode = "US", NationalDestinationCode = "312", Features = new List<string> { "mms" }, Reservable = false });
            //this.AssertRequest(HttpMethod.Get, "/v2/available_phone_numbers");
            Assert.NotNull(numberSearch);
            Assert.Equal("Telnyx.AvailablePhoneNumber", numberSearch.Data[0].GetType().ToString());
            Assert.Single(numberSearch.Data);
        }

        [Fact]
        public async Task ListWithOptionsAsync()
        {
            var numberSearch = await this.numberSearchService.ListAsync(new NumberSearchOptions { CountryCode = "US", NationalDestinationCode = "312" });
            //this.AssertRequest(HttpMethod.Get, "/v2/available_phone_numbers");
            Assert.NotNull(numberSearch);
            Assert.Equal("Telnyx.AvailablePhoneNumber", numberSearch.Data[0].GetType().ToString());
            Assert.Single(numberSearch.Data);
        }

        [Fact]
        public async Task ListAsync()
        {
            var numberSearch = await this.numberSearchService.ListAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/available_phone_numbers");
            Assert.NotNull(numberSearch);
            Assert.Single(numberSearch.Data);
            Assert.Equal("Telnyx.AvailablePhoneNumber", numberSearch.Data[0].GetType().ToString());
        }
    }
}
