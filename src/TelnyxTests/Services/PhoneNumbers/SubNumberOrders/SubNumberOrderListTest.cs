namespace TelnyxTests.Services.PhoneNumbers.SubNumberOrders

{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;
    using Telnyx.net.Services.PhoneNumbers.SubNumberOrders;
    using Xunit;

    /// <summary>
    /// Test class for SubNumberOrderTest.
    /// </summary>
    public class SubNumberOrderTest : BaseTelnyxTest
    {
        private readonly SubNumberOrderService service;
        private readonly SubNumberOrderListOptions SubNumberOrderListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SubNumberOrderTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SubNumberOrderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.SubNumberOrderListOptions = new SubNumberOrderListOptions()
            {
                UserId = new Guid("d70873cd-7c98-401a-81b6-b1ae08246995"),
                OrderRequestId = new Guid("d70873cd-7c98-401a-81b6-b1ae08246995"),
                CountryCode = "us",
                PhoneNumberType = "local",
                PhoneNumbersCount = 1,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListSubNumberOrders(this.SubNumberOrderListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SubNumberOrder>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListSubNumberOrdersAsync(this.SubNumberOrderListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SubNumberOrder>), result.GetType());
        }
    }
}
