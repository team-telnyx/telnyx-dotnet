namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards.SIMCardNetworkPreference;
    using Xunit;

    public class SimCardNetworkPreferenceServiceTest : BaseTelnyxTest
    {
        private readonly BaseOptions baseOptions;
        private readonly RequestOptions requestOptions;
        private readonly UpsertSIMCardNetworkPreference createOptions;
        private string simCardNetworkPreferenceId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly SIMCardNetworkPreferenceService service;
        private string parentId = "";

        public SimCardNetworkPreferenceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.baseOptions = new BaseOptions { };
            this.requestOptions = new RequestOptions() { };
            this.service = new SIMCardNetworkPreferenceService();
            this.createOptions = new UpsertSIMCardNetworkPreference()
            {
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.simCardNetworkPreferenceId, parentId, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SettingSIMCardPublicIP), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.simCardNetworkPreferenceId, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(SettingSIMCardPublicIP), result.GetType());
        }
    }
}


