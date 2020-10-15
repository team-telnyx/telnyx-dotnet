namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardBulkNetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly SimCardBulkNetworkPreferenceService service;
        private readonly SimCardBulkNetworkPreferenceUpdateOptions options;

        public SimCardBulkNetworkPreferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.options = new SimCardBulkNetworkPreferenceUpdateOptions { SimCardIds = new string[] { "001", "002" } };
            this.service = new SimCardBulkNetworkPreferenceService();
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Update(options);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.UpdateAsync(options);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }
    }
}



