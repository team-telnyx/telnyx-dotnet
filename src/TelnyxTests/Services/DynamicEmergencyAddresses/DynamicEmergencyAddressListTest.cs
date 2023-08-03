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
            var result = this.service.ListDynamicEmergencyAddresss(this.DynamicEmergencyAddressListOptions, this.requestOptions);
            AssertListResponse(result);
        }

        [Fact]
        public async Task ListDynamicEmergencyAddresssAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListDynamicEmergencyAddresssAsync(this.DynamicEmergencyAddressListOptions, this.requestOptions, cts.Token);
            AssertListResponse(result);
        }

        private static void AssertListResponse(TelnyxList<DynamicEmergencyAddress> result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<DynamicEmergencyAddress>), result.GetType());
            Assert.Collection(result.Data, (first) => {
                Assert.Equal("IL", first.AdministrativeArea);
                Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, first.CountryCode);
                Assert.Equal("02/02/2018 22:25:27", first.CreatedAt);
                Assert.Equal("string", first.ExtendedAddress);
                Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f1", first.Id);
                Assert.Equal("Chicago", first.Locality);
                Assert.Equal("60654", first.PostalCode);
                Assert.Equal("dynamic_emergency_address", first.RecordType);
                Assert.Equal("XYZ123", first.SipGeolocationId);
                Assert.Equal("pending", first.Status);
                Assert.Equal("Superior", first.StreetName);
                Assert.Equal("string", first.StreetPostDirectional);
                Assert.Equal("W", first.StreetPreDirectional);
                Assert.Equal("string", first.StreetSuffix);
                Assert.Equal("02/02/2018 22:25:27", first.UpdatedAt);
            });
        }

        [Fact]
        public void Retrieve()
        {
            var response = this.service.RetrieveDynamicEmergencyAddress(Id, this.baseOptions, this.requestOptions);
            AssertRetrieve(response);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var cts = new CancellationTokenSource();
            var response = await this.service.RetrieveDynamicEmergencyAddressAsync(Id, this.baseOptions, this.requestOptions, cts.Token);
            AssertRetrieve(response);
        }

        private static void AssertRetrieve(DynamicEmergencyAddress response)
        {
            Assert.NotNull(response);
            Assert.Equal(typeof(DynamicEmergencyAddress), response.GetType());
            Assert.Equal("IL", response.AdministrativeArea);
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, response.CountryCode);
            Assert.Equal("2018-02-02T22:25:27.521Z", response.CreatedAt);
            Assert.Equal("string", response.ExtendedAddress);
            Assert.Equal("0ccc7b54-4df3-4bca-a65a-3da1ecc777f1", response.Id);
            Assert.Equal("Chicago", response.Locality);
            Assert.Equal("60654", response.PostalCode);
            Assert.Equal("dynamic_emergency_address", response.RecordType);
            Assert.Equal("XYZ123", response.SipGeolocationId);
            Assert.Equal("pending", response.Status);
            Assert.Equal("Superior", response.StreetName);
            Assert.Equal("string", response.StreetPostDirectional);
            Assert.Equal("W", response.StreetPreDirectional);
            Assert.Equal("string", response.StreetSuffix);
            Assert.Equal("2018-02-02T22:25:27.521Z", response.UpdatedAt);
        }
    }
}
