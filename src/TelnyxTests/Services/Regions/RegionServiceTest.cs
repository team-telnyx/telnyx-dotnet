namespace TelnyxTests.Services.Regions.RegionServiceTest
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Regions;
    using Telnyx.net.Services.Regions;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class RegionServiceTest : BaseTelnyxTest
    {
        private readonly RegionService service;
        private readonly RequestOptions requestOptions;

        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public RegionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RegionService();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNumbersAssociatedToOrders(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<Region>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNumbersAssociatedToOrdersAsync(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<Region>), result.GetType());
        }


    }
}