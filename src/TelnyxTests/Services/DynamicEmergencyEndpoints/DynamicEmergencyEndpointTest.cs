namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyEndpoint
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints;
    using Telnyx.net.Services.DynamicEmergencyEndpoints;
    using Xunit;
    using DynamicEmergencyEndpointModel = Telnyx.net.Entities.DynamicEmergencyEndpoints.DynamicEmergencyEndpoint;

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
            AssertResponse(result);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateDynamicEmergencyEndpointAsync(this.DynamicEmergencyEndpointOptions, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteCredentialConnection(Id, this.requestOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteCredentialConnectionAsync(Id, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        private static void AssertResponse(DynamicEmergencyEndpointModel result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(DynamicEmergencyEndpointModel), result.GetType());
            Assert.Equal("+13125550000", result.CallbackNumber);
            Assert.Equal("Jane Doe Desk Phone", result.CallerName);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.CreatedAt);
            Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f0", result.DynamicEmergencyAddressId);
            Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f0", result.Id);
            Assert.Equal("dynamic_emergency_endpoint", result.RecordType);
            Assert.Equal("FXDFWEDF", result.SipFromId);
            Assert.Equal(DynamicEmergencyAddressStatus.Pending, result.Status);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.UpdatedAt);
        }
    }
}
