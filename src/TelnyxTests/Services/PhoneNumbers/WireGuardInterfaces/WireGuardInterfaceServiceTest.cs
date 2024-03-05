namespace TelnyxTests.Services.PhoneNumbers.WireGuardInterfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces;
    using Telnyx.net.Services.PhoneNumbers.WireGuardInterfaces;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class WireGuardInterfaceServiceTest : BaseTelnyxTest
    {
        private readonly WireGuardInterfaceService service;
        private readonly WireGuardInterfaceOption listOptions;
        private readonly UpsertWireGuardInterface createOptions;
        private readonly RequestOptions requestOptions;

        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public WireGuardInterfaceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new WireGuardInterfaceService();

            this.listOptions = new WireGuardInterfaceOption()
            {
                NetworkIdFilter = "6a09cdc3-8948-47f0-aa62-74ac943d6c58"
            };
            this.createOptions = new UpsertWireGuardInterface()
            {
                NetworkId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Name = "test interface",
                EnableSipTrunking = true,
                RegionCode = "ashburn-va"
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListWireGuardInterface(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardInterface>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListWireGuardInterfaceAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardInterface>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetWireGuardInterface(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardInterface), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetWireGuardInterfaceAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardInterface), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateWireGuardInterface(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WireGuardInterface), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateWireGuardInterfaceAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WireGuardInterface), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteWireGuardInterface(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardInterface), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteWireGuardInterfaceAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardInterface), message.GetType());
        }
    }
}