namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardDisableServiceTest : BaseTelnyxTest
    {
        private readonly SimCardDisableService service;

        private const string parentId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardDisableServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardDisableService();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(parentId);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAsync(parentId);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }
    }
}
