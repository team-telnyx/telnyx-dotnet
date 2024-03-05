using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.WireGuardPeers;
using Telnyx.net.Services.PhoneNumbers.WireGuardPeers;
using Xunit;

namespace TelnyxTests.Services.Wireguards
{
    public class WireGuardPeerServiceTest : BaseTelnyxTest
    {
        private readonly WireGuardPeerService service;
        private readonly WireGuardPeerOption listOptions;
        private readonly UpsertWireGuardPeer createOptions;
        private readonly RequestOptions requestOptions;
        private readonly string credConnId = "1234";
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public WireGuardPeerServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new WireGuardPeerService();

            this.listOptions = new WireGuardPeerOption()
            {
            };
            this.createOptions = new UpsertWireGuardPeer()
            {
                PublicKey = "qF4EqlZq+5JL2IKYY8ij49daYyfKVhevJrcDxdqC8GU=",
                WireGuardInterfaceId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58")
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListWireGuardPeer(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardPeer>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListWireGuardPeerAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardPeer>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetWireGuardPeer(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetWireGuardPeerAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateWireGuardPeer(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WireGuardPeer), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateWireGuardPeerAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(WireGuardPeer), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteWireGuardPeer(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteWireGuardPeerAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateWireGuardPeer(this.credConnId, this.createOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateWireGuardPeerAsync(this.credConnId, this.createOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(WireGuardPeer), message.GetType());
        }
    }
}
