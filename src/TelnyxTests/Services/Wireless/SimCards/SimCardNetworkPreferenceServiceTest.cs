namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardNetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly BaseOptions baseOptions;
        private readonly RequestOptions requestOptions;
        private string simCardNetworkPreferenceId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly SimCardNetworkPreferenceService service;

        public SimCardNetworkPreferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.baseOptions = new BaseOptions { };
            this.requestOptions = new RequestOptions() { };
            this.service = new SimCardNetworkPreferenceService();
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(this.simCardNetworkPreferenceId, this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(this.simCardNetworkPreferenceId, this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(this.simCardNetworkPreferenceId, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(this.simCardNetworkPreferenceId, this.requestOptions, new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }
    }
}


