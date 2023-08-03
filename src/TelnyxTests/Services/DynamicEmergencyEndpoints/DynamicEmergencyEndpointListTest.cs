namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyEndpointList
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints;
    using Telnyx.net.Services.DynamicEmergencyEndpoints;
    using Xunit;
    using DynamicEmergencyEndpointModel = Telnyx.net.Entities.DynamicEmergencyEndpoints.DynamicEmergencyEndpoint;

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
            Assert.Equal(typeof(TelnyxList<DynamicEmergencyEndpointModel>), result.GetType());
            AssertResponse(result.Data);
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListDynamicEmergencyEndpointsAsync(this.DynamicEmergencyEndpointListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<DynamicEmergencyEndpointModel>), result.GetType());
            AssertResponse(result.Data);
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveDynamicEmergencyEndpoint(Id, this.baseOptions, this.requestOptions);
            AssertRetrieve(result);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveDynamicEmergencyEndpointAsync(Id, this.baseOptions, this.requestOptions, cts.Token);
            AssertRetrieve(result);
        }

        private static void AssertResponse(List<DynamicEmergencyEndpointModel> results)
        {
            Assert.NotNull(results);
            Assert.Collection(results, result =>
            {
                Assert.Equal(typeof(DynamicEmergencyEndpointModel), result.GetType());
                Assert.Equal("+13125550000", result.CallbackNumber);
                Assert.Equal("Jane Doe Desk Phone", result.CallerName);
                Assert.Equal("02/02/2018 22:25:27", result.CreatedAt);
                Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f0", result.DynamicEmergencyAddressId);
                Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f0", result.Id);
                Assert.Equal("dynamic_emergency_endpoint", result.RecordType);
                Assert.Equal("FXDFWEDF", result.SipFromId);
                Assert.Equal(DynamicEmergencyAddressStatus.Pending, result.Status);
                Assert.Equal("02/02/2018 22:25:27", result.UpdatedAt);
            });
        }

        private static void AssertRetrieve(DynamicEmergencyEndpointModel result)
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
