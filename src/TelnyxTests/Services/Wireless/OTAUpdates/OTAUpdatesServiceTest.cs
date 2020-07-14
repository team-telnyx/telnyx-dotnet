namespace TelnyxTests.Services.Wireless.MobileOperatorNetworks
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.OTAUpdates;
    using Telnyx.net.Services.Wireless.OTAUpdatesService;
    using Xunit;

    public class OTAUpdatesServiceTest : BaseTelnyxTest
    {
        private readonly OTAUpdatesService service;
        private readonly ListOTAUpdatesOptions listOptions;
        private readonly RequestOptions requestOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public OTAUpdatesServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new OTAUpdatesService();

            this.listOptions = new ListOTAUpdatesOptions
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.requestOptions = new RequestOptions();
        }
        
        [Fact(Skip = "Mock not working")]
        public void Get()
        {
            var result = this.service.Get(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OTAUpdatesRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OTAUpdatesRecord), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OTAUpdatesRecord), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(OTAUpdatesRecord), result.Data[0].GetType());
        }
    }
}
