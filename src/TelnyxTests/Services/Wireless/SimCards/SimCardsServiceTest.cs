namespace TelnyxTests.Services.Wireless.SimCards
{
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardsServiceTest : BaseTelnyxTest
    {
        private readonly SimCardsService service;
        private readonly ListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardsService();

            this.listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.baseOptions = new BaseOptions();
            this.baseOptions.AddExtraParam("include_sim_card_group", "true");

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.Data[0].GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }
    }
}
