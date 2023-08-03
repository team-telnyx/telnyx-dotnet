namespace TelnyxTests.Services.PhoneNumbers.SubNumberOrders

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;
    using Telnyx.net.Services.PhoneNumbers.SubNumberOrders;
    using Xunit;

    /// <summary>
    /// Test class for RetrieveSubNumberOrdersTest.
    /// </summary>
    public class RetrieveSubNumberOrdersTest : BaseTelnyxTest
    {
        private readonly SubNumberOrderService service;
        private readonly RetrieveSubNumberOrderOption RetrieveSubNumberOrderOption;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public RetrieveSubNumberOrdersTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SubNumberOrderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.RetrieveSubNumberOrderOption = new RetrieveSubNumberOrderOption()
            {
                IncludePhoneNumbers = false,
            };
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveSubNumberOrders(Id, this.RetrieveSubNumberOrderOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SubNumberOrder), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveSubNumberOrdersAsync(Id, this.RetrieveSubNumberOrderOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(SubNumberOrder), result.GetType());
        }
    }
}
