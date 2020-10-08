namespace TelnyxTests.Services.Wireless.SimCards
{
    using Xunit;
    using Telnyx;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;

    public class SimCardNetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly BaseOptions baseOptions;
        private readonly RequestOptions requestOptions;
        private string simCardNetworkPreferenceId = "0001";
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
            var result = this.service.Get(simCardNetworkPreferenceId, this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(simCardNetworkPreferenceId, this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(simCardNetworkPreferenceId, requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(simCardNetworkPreferenceId, requestOptions, new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }
    }
}


