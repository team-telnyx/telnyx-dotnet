namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyAddresses
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.DynamicEmergencyAddresses;
    using Telnyx.net.Services.DynamicEmergencyAddresses;
    using Xunit;

    // <summary>
    // Test class for DynamicEmergencyAddresses.
    // </summary>
    public class CreateDynamicEmergencyAddressTest : BaseTelnyxTest
    {
        private readonly DynamicEmergencyAddressesService service;
        private readonly CreateDynamicEmergencyAddressOptions createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateDynamicEmergencyAddressTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DynamicEmergencyAddressesService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.createOptions = new CreateDynamicEmergencyAddressOptions()
            {
                AdministrativeArea = "",
                CountryCode = Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US,
                CountryCoude = "USA",
                ExtendedAddress = "",
                HouseNumber = "",
                HouseSuffix = "",
                Locality = "",
                PostalCode = "",
                StreetName = "",
                StreetPostDirectional = "",
                StreetPreDirectional = "",
                StreetSuffix = "",
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateDynamicEmergencyAddress(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(DynamicEmergencyAddress), result.GetType());
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, result.CountryCode);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateDynamicEmergencyAddressAsync(this.createOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(DynamicEmergencyAddress), result.GetType());
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, result.CountryCode);
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteDynamicEmergencyAddress(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(DynamicEmergencyAddress), result.GetType());
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, result.CountryCode);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteDynamicEmergencyAddressAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(DynamicEmergencyAddress), result.GetType());
            Assert.Equal(Telnyx.net.Entities.Enum.DynamicEmergencyAddresses.CountryCode.US, result.CountryCode);
        }
    }
}
