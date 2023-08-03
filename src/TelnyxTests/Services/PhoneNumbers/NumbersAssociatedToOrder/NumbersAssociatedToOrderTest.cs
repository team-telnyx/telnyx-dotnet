namespace TelnyxTests.Services.PhoneNumbers.NumbersAssociatedToOrder

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.PhoneNumbers.NumbersAssociatedToOrders;
    using Xunit;
    using NumbersAssociatedToOrderModel = Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders.NumbersAssociatedToOrder;

    /// <summary>
    /// Test class for NumbersAssociatedToOrderTest.
    /// </summary>
    public class NumbersAssociatedToOrderTest : BaseTelnyxTest
    {
        private readonly NumbersAssociatedToOrderService service;
        private readonly UpdateNumbersAssociatedToOrderOptions UpdateNumbersAssociatedToOrderOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NumbersAssociatedToOrderTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumbersAssociatedToOrderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.UpdateNumbersAssociatedToOrderOptions = new UpdateNumbersAssociatedToOrderOptions()
            {
                RegulatoryRequirements = new System.Collections.Generic.List<Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders.UpdateRegulatoryRequirement>
                {
                    new Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders.UpdateRegulatoryRequirement
                    {
                        FieldValue = "fv",
                        RequirementId = Id,
                    },
                },
            };
        }

        [Fact]
        public void Update()
        {
            var result = this.service.UpdateNumbersAssociatedToOrder(Id, this.UpdateNumbersAssociatedToOrderOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumbersAssociatedToOrderModel), result.GetType());
        }

        [Fact]
        public async Task UpdateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateNumbersAssociatedToOrderAsync(Id, this.UpdateNumbersAssociatedToOrderOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumbersAssociatedToOrderModel), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListNumbersAssociatedToOrders(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumbersAssociatedToOrderModel>), result.GetType());
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListNumbersAssociatedToOrdersAsync(this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NumbersAssociatedToOrderModel>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveNumbersAssociatedToOrders(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumbersAssociatedToOrderModel), result.GetType());
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveNumbersAssociatedToOrdersAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumbersAssociatedToOrderModel), result.GetType());
        }
    }
}
