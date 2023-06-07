namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyAddressList
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.DynamicEmergencyAddresses;
    using Telnyx.net.Services.Documents;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;
    using static Telnyx.net.Services.DynamicEmergencyAddresses.DynamicEmergencyAddressesService;
    using System.Threading;

    // <summary>
    // Test class for DynamicEmergencyAddressList.
    // </summary>
    public class CreateDynamicEmergencyAddressTest : BaseTelnyxTest
    {
        private readonly DynamicEmergencyAddressesService service;
        private readonly DynamicEmergencyAddressListOptions DynamicEmergencyAddressListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateDynamicEmergencyAddressTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DynamicEmergencyAddressesService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.DynamicEmergencyAddressListOptions = new DynamicEmergencyAddressListOptions()
            {
                

            };

        }

        [Fact]
        public void Create()
        {
            var result = this.service.ListDynamicEmergencyAddresss(this.DynamicEmergencyAddressListOptions , this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.ListDynamicEmergencyAddresssAsync(this.DynamicEmergencyAddressListOptions , this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveDynamicEmergencyAddress(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public void RetrieveAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.RetrieveDynamicEmergencyAddressAsync(Id, this.baseOptions,this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
