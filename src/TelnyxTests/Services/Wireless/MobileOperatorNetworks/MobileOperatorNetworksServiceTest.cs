﻿namespace TelnyxTests.Services.Wireless.MobileOperatorNetworks
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.MobileOperatorNetworks;
    using Telnyx.net.Services.Wireless.MobileOperatorNetworks;
    using Xunit;

    public class MobileOperatorNetworksServiceTest : BaseTelnyxTest
    {
        private readonly MobileOperatorNetworksService service;
        private readonly ListMobileOperatorNetworksOptions listOptions;
        private readonly RequestOptions requestOptions;

        private List<MobileOperatorNetworksRecord> results;

        public MobileOperatorNetworksServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MobileOperatorNetworksService();

            this.listOptions = new ListMobileOperatorNetworksOptions
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksRecord), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksRecord), result.Data[0].GetType());
        }
    }
}
