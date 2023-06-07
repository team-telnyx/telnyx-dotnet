namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyEndpoint
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.DynamicEmergencyEndpoints;
    using Telnyx.net.Services.Documents;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;
    using static Telnyx.net.Services.DynamicEmergencyEndpoints.DynamicEmergencyEndpointOptions;
    using System.Threading;

    // <summary>
    // Test class for DynamicEmergencyEndpoint.
    // </summary>
    public class CreateDynamicEmergencyEndpointTest : BaseTelnyxTest
    {
        private readonly DynamicEmergencyEndpointsService service;
        private readonly DynamicEmergencyEndpointOptions DynamicEmergencyEndpointOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateDynamicEmergencyEndpointTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DynamicEmergencyEndpointsService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.DynamicEmergencyEndpointOptions = new DynamicEmergencyEndpointOptions()
            {
                CallbackNumber = "",
                CallerName = "",
                DynamicEmergencyAddressId = "",

            };

        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateDynamicEmergencyEndpoint(this.DynamicEmergencyEndpointOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.CreateDynamicEmergencyEndpointAsync(this.DynamicEmergencyEndpointOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteCredentialConnection(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public void DeleteAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.DeleteCredentialConnectionAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
