namespace TelnyxTests.Services.Wireless.SimCards.PublicInternetGateways
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.PublicInternetGateways;
    using Telnyx.net.Services.Wireless.PublicInternetGateways;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class PublicInternetGatewayServiceTest : BaseTelnyxTest
    {
        private readonly PublicInternetGatewayService service;
        private readonly PublicInternetGatewayOption listOptions;
        private readonly UpsertPublicInternetGateway createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public PublicInternetGatewayServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PublicInternetGatewayService();

            this.listOptions = new PublicInternetGatewayOption()
            {
                NetworkIdFilter = "6a09cdc3-8948-47f0-aa62-74ac943d6c58"
            };
            this.createOptions = new UpsertPublicInternetGateway()
            {
                NetworkId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Name = "test interface",
                RegionCode = "ashburn-va"
            };

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListPublicInternetGateway(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PublicInternetGateway>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPublicInternetGatewayAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PublicInternetGateway>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetPublicInternetGateway(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PublicInternetGateway), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetPublicInternetGatewayAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PublicInternetGateway), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateNetwork(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PublicInternetGateway), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateNetworkAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PublicInternetGateway), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeletePublicInternetGateway(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(PublicInternetGateway), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeletePublicInternetGatewayAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(PublicInternetGateway), message.GetType());
        }
    }
}