namespace TelnyxTests.Services.Wireless.SimCards.PrivateWirelessGateways
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.PrivateWirelessGateways;
    using Telnyx.net.Services.Wireless.PrivateWirelessGateways;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class PrivateWirelessGatewayServiceTest : BaseTelnyxTest
    {
        private readonly PrivateWirelessGatewayService service;
        private readonly PrivateWirelessGatewayOption listOptions;
        private readonly UpsertPrivateWirelessGateway createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public PrivateWirelessGatewayServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PrivateWirelessGatewayService();

            this.listOptions = new PrivateWirelessGatewayOption()
            {
                Name = "My private wireless gateway",
                IpRange = "100.64.1.0/24",
                RegionCode = "ashburn-va",
                CreatedAt = "2018-02-02T22:25:27.521Z",
                UpdatedAt = "2018-02-02T22:25:27.521Z"
            };
            this.createOptions = new UpsertPrivateWirelessGateway()
            {
                NetworkId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Name = "My private wireless gateway",
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListPrivateWirelessGatewayOption(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PrivateWirelessGateway>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPrivateWirelessGatewayOptionAsync(this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PrivateWirelessGateway>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetPrivateWirelessGateway(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PrivateWirelessGateway), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetPrivateWirelessGatewayAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PrivateWirelessGateway), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreatePrivateWirelessGateway(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PrivateWirelessGateway), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreatePrivateWirelessGatewayAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PrivateWirelessGateway), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeletePrivateWirelessGateway(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(PrivateWirelessGateway), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeletePrivateWirelessGatewayAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(PrivateWirelessGateway), message.GetType());
        }
    }
}