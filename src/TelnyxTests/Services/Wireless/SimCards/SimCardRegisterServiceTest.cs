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
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<SimCardRecord>), result.GetType());
            var response = result.Data.FirstOrDefault();
            Assert.Equal(this.simCardRegisterOptions.SimCardGroupId, response.SimCardGroupId.ToString());
            Assert.Equal(this.simCardRegisterOptions.Tags.Length, response.Tags.Count());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.simCardRegisterOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<SimCardRecord>), result.GetType());
        }
    }
}

