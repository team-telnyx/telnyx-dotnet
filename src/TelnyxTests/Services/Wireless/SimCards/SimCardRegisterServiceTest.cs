namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Linq;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardRegisterServiceTest : BaseTelnyxTest
    {
        private readonly SimCardRegisterService service;
        private readonly SimCardRegisterOptions simCardRegisterOptions;

        public SimCardRegisterServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardRegisterService();
            this.simCardRegisterOptions = new SimCardRegisterOptions
            {
                RegistrationCodes = new string[]
                {
                    "0000000001",
                    "0000000002",
                    "0000000003",
                },
                SimCardGroupId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58",
                Tags = new string[]
                {
                    "personal",
                    "customers",
                    "active-customers",
                },
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.simCardRegisterOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.simCardRegisterOptions);
            AssertResponse(result);
        }

        private static void AssertResponse(TelnyxList<SimCardRecord> result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SimCardRecord>), result.GetType());
            var response = result.Data.FirstOrDefault();
            Assert.Equal("6a09cdc3-8948-47f0-aa62-74ac943d6c58", response.SimCardGroupId.ToString());
            Assert.Equal(3, response.Tags.Count());
            Assert.Equal("6a09cdc3-8948-47f0-aa62-74ac943d6c58", response.Id);
            Assert.Equal("081932214823362973", response.Imsi);
            Assert.Equal("+13109976224", response.Msisdn);
            Assert.NotNull(response.CreatedAt);
            Assert.NotNull(response.UpdatedAt);
            Assert.NotNull(response.Status);
        }
    }
}
