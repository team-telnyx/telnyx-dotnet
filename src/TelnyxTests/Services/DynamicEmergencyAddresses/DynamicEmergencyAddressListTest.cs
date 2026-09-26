namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyAddressList
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.DynamicEmergencyAddresses;
    using Telnyx.net.Services.DynamicEmergencyAddresses;
    using Xunit;

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
        public void ListDynamicEmergencyAddresss()
        {
            var result = DynamicEmergencyAddressResponseFixture.Send(
                () => Task.FromResult(this.service.ListDynamicEmergencyAddresss(this.DynamicEmergencyAddressListOptions, this.requestOptions)),
                "list", "/v2/dynamic_emergency_addresses?filter[status]=pending&").GetAwaiter().GetResult();
            AssertListResponse(result);
        }

        [Fact]
        public async Task ListDynamicEmergencyAddresssAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await DynamicEmergencyAddressResponseFixture.Send(
                () => this.service.ListDynamicEmergencyAddresssAsync(this.DynamicEmergencyAddressListOptions, this.requestOptions, cts.Token),
                "list", "/v2/dynamic_emergency_addresses?filter[status]=pending&");
            AssertListResponse(result);
        }

        private static void AssertListResponse(TelnyxList<DynamicEmergencyAddress> result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<DynamicEmergencyAddress>), result.GetType());
            Assert.Collection(result.Data, (first) => {
                Assert.Equal("TX", first.AdministrativeArea);
                Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, first.CountryCode);
                Assert.Equal("02/02/2018 22:25:27", first.CreatedAt);
                Assert.Equal("string", first.ExtendedAddress);
                Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f1", first.Id);
                Assert.Equal("Austin", first.Locality);
                Assert.Equal("78701", first.PostalCode);
                Assert.Equal("dynamic_emergency_address", first.RecordType);
                Assert.Equal("XYZ123", first.SipGeolocationId);
                Assert.Equal("pending", first.Status);
                Assert.Equal("Congress", first.StreetName);
                Assert.Equal("string", first.StreetPostDirectional);
                Assert.Equal("W", first.StreetPreDirectional);
                Assert.Equal("St", first.StreetSuffix);
                Assert.Equal("02/02/2018 22:25:27", first.UpdatedAt);
            });
        }

        [Fact]
        public void Retrieve()
        {
            var response = DynamicEmergencyAddressResponseFixture.Send(
                () => Task.FromResult(this.service.RetrieveDynamicEmergencyAddress(Id, this.baseOptions, this.requestOptions)),
                "retrieve", "/v2/dynamic_emergency_addresses/" + Id).GetAwaiter().GetResult();
            AssertRetrieve(response);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var cts = new CancellationTokenSource();
            var response = await DynamicEmergencyAddressResponseFixture.Send(
                () => this.service.RetrieveDynamicEmergencyAddressAsync(Id, this.baseOptions, this.requestOptions, cts.Token),
                "retrieve", "/v2/dynamic_emergency_addresses/" + Id);
            AssertRetrieve(response);
        }

        // Additional controls against the current-spec shared mock. Full-field assertions
        // remain in the four original tests backed by explicitly synthetic fixtures.
        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task CurrentSpecIntegrationControl(bool retrieve, bool asynchronous)
        {
            DynamicEmergencyAddress address;
            if (retrieve)
            {
                address = asynchronous
                    ? await this.service.RetrieveDynamicEmergencyAddressAsync(Id, this.baseOptions, this.requestOptions)
                    : this.service.RetrieveDynamicEmergencyAddress(Id, this.baseOptions, this.requestOptions);
            }
            else
            {
                var result = asynchronous
                    ? await this.service.ListDynamicEmergencyAddresssAsync(this.DynamicEmergencyAddressListOptions, this.requestOptions)
                    : this.service.ListDynamicEmergencyAddresss(this.DynamicEmergencyAddressListOptions, this.requestOptions);
                Assert.NotNull(result);
                address = Assert.Single(result.Data);
            }

            Assert.NotNull(address);
            Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f1", address.Id);
            Assert.Equal("dynamic_emergency_address", address.RecordType);
            Assert.Equal("pending", address.Status);
            Assert.Equal("Austin", address.Locality);
            Assert.Equal("string", address.StreetPreDirectional);
            Assert.Equal(retrieve ? "2018-02-02T22:25:27.521Z" : "02/02/2018 22:25:27", address.CreatedAt);
            Assert.Equal(retrieve ? "2018-02-02T22:25:27.521Z" : "02/02/2018 22:25:27", address.UpdatedAt);
        }

        private static void AssertRetrieve(DynamicEmergencyAddress response)
        {
            Assert.NotNull(response);
            Assert.Equal(typeof(DynamicEmergencyAddress), response.GetType());
            Assert.Equal("TX", response.AdministrativeArea);
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, response.CountryCode);
            Assert.Equal("2018-02-02T22:25:27.521Z", response.CreatedAt);
            Assert.Equal("string", response.ExtendedAddress);
            Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f1", response.Id);
            Assert.Equal("Austin", response.Locality);
            Assert.Equal("78701", response.PostalCode);
            Assert.Equal("dynamic_emergency_address", response.RecordType);
            Assert.Equal("XYZ123", response.SipGeolocationId);
            Assert.Equal("pending", response.Status);
            Assert.Equal("Congress", response.StreetName);
            Assert.Equal("string", response.StreetPostDirectional);
            Assert.Equal("W", response.StreetPreDirectional);
            Assert.Equal("St", response.StreetSuffix);
            Assert.Equal("2018-02-02T22:25:27.521Z", response.UpdatedAt);
        }
    }
}
