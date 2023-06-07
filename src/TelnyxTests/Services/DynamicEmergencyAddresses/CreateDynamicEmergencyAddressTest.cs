namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyAddresses
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
                ExtendedAddress = "",
                HouseNumber = "",
                HouseSuffix= "",
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
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.CreateDynamicEmergencyAddressAsync(this.createOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteDynamicEmergencyAddress(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
        public void DeleteAsync()
        {
            var cts = new CancellationTokenSource();
            var result = this.service.DeleteDynamicEmergencyAddressAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
