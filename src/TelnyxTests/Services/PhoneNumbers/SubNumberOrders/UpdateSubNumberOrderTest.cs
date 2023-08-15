namespace TelnyxTests.Services.PhoneNumbers.UpdateSubNumberOrders

{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;
    using Telnyx.net.Services.PhoneNumbers.SubNumberOrders;
    using Xunit;

    /// <summary>
    /// Test class for UpdateSubNumberOrderTest.
    /// </summary>
    public class UpdateSubNumberOrderTest : BaseTelnyxTest
    {
        private readonly SubNumberOrderService service;
        private readonly UpdateSubNumberOrderOptions UpdateSubNumberOrderOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public UpdateSubNumberOrderTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SubNumberOrderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.UpdateSubNumberOrderOptions = new UpdateSubNumberOrderOptions()
            {
                RegulatoryRequirements = new System.Collections.Generic.List<UpdateRegulatoryRequirement>
                {
                    new UpdateRegulatoryRequirement()
                    {
                        FieldValue = "avb",
                        RequirementId = "6a09cdc3-8948-47f0-aa62-74ac943d6c99",
                    },
                },
            };
        }

        [Fact]
        public void Update()
        {
            var result = this.service.UpdateSubNumberOrder(Id, this.UpdateSubNumberOrderOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SubNumberOrder), result.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateSubNumberOrderAsync(Id, this.UpdateSubNumberOrderOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(SubNumberOrder), result.GetType());
        }
    }
}
