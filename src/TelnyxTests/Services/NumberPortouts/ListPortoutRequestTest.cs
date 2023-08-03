namespace TelnyxTests.Services.Notifications.Notifications.ListPortoutRequests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberPortouts;
    using Telnyx.net.Services.NumberPortouts;
    using Xunit;

    /// <summary>
    /// Test class for ListPortoutRequestTest.
    /// </summary>
    public class ListPortoutRequestTest : BaseTelnyxTest
    {
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly NumberPortoutService service;
        private readonly ListPortoutRequestOptions listPortoutRequestOptions;
        private readonly RequestOptions requestOptions;

        public ListPortoutRequestTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberPortoutService();
            this.requestOptions = new RequestOptions();
            this.listPortoutRequestOptions = new ListPortoutRequestOptions()
            {
            };
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveNumberPortouts(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortoutDetails), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNumberPortoutsAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PortoutDetails), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListPortoutRequests(this.listPortoutRequestOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortoutDetails>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPortoutRequestsAsync(this.listPortoutRequestOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PortoutDetails>), result.GetType());
        }
    }
}
