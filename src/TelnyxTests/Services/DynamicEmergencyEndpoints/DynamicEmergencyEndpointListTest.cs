namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyEndpointList
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.DynamicEmergencyEndpoints;
    using Telnyx.net.Services.Documents;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;
    using static Telnyx.net.Services.DynamicEmergencyEndpoints.DynamicEmergencyEndpointListOptions;
    using System.Threading;

    // <summary>
    // Test class for DynamicEmergencyEndpointList.
    // </summary>
    public class CreateDynamicEmergencyEndpointTest : BaseTelnyxTest
    {
        private readonly DynamicEmergencyEndpointsService service;
        private readonly DynamicEmergencyEndpointListOptions DynamicEmergencyEndpointListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateDynamicEmergencyEndpointTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DynamicEmergencyEndpointsService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.DynamicEmergencyEndpointListOptions = new DynamicEmergencyEndpointListOptions()
            {
                Status = Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints.DynamicEmergencyAddressStatus.Pending,
                CountryCode = "",

            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.ListDynamicEmergencyEndpoints(this.DynamicEmergencyEndpointListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.ListDynamicEmergencyEndpointsAsync(this.DynamicEmergencyEndpointListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveDynamicEmergencyEndpoint(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public void RetrieveAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.RetrieveDynamicEmergencyEndpointAsync(Id, this.baseOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
