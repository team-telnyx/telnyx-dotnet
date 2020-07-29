namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    /// <summary>
    /// SimCardRegisterServiceTest.
    /// </summary>
    public class SimCardRegisterServiceTest : BaseTelnyxTest
    {
        private readonly SimCardRegisterService service;
        private readonly SimCardRegisterOptions baseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardRegisterServiceTest"/> class.
        /// Initial public constructor for the test class.
        /// </summary>
        public SimCardRegisterServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardRegisterService();
            this.baseOptions = new SimCardRegisterOptions
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
            var result = this.service.Create(this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecordList), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(this.baseOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecordList), result.GetType());
        }
    }
}
