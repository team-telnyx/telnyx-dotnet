namespace TelnyxTests.Wireless.SimCards.SimCardGroupActions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards.SimCardGroupActions;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class SimCardGroupActionServiceTest : BaseTelnyxTest
    {
        private readonly SimCardGroupActionService service;
        private readonly SimCardGroupActionOption listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardGroupActionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardGroupActionService();

            this.listOptions = new SimCardGroupActionOption
            {
                SimCardGroupId = new System.Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Status = "in-progress",
                ActionType = "set_private_wireless_gateway" 
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListSimCardGroupAction(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SimCardGroupAction>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListSimCardGroupActionAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SimCardGroupAction>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetSimCardGroupAction(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(SimCardGroupAction), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetSimCardGroupActionAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(SimCardGroupAction), message.GetType());
        }
    }
}