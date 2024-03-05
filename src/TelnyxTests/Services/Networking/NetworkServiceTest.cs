using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Networking.Networks;
using Telnyx.net.Services.Networking;
using Xunit;

namespace TelnyxTests.Services.Networking
{
    public class NetworkServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly NetworkService service;
        private readonly NetworkOptions listOptions;
        private readonly UpsertNetwork createOptions;

        public NetworkServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NetworkService();

            this.listOptions = new  NetworkOptions()
            {
                Name = "test network"
            };
            this.createOptions = new UpsertNetwork()
            {
            };
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListNetworks(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<Network>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListNetworksAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<Network>), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var message = this.service.CreateNetwork(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateNetworkAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteNetwork(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteNetworkAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateNetwork(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateNetworkAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetNetwork(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetNetworkAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Network), message.GetType());
        }
    }
}
