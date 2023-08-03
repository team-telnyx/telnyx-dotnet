namespace TelnyxTests.Services.Wireless.MobileOperatorNetworks
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
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
                FilterNameStartsWith = null,
                FilterNameContains = null,
                FilterNameEndsWith = null,
                FilterCountryCode = null,
                FilterMcc = null,
                FilterMnc = null,
                FilterTadig = null
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact(Skip = "Mocks does not contain this api")]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<MobileOperatorNetworksRecord>), result.GetType());
        }

        [Fact(Skip = "Mocks does not contain this api")]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<MobileOperatorNetworksRecord>), result.GetType());
        }
    }
}
