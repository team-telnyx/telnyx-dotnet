using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPConnections;
using Telnyx.net.Services.Connections;
using Telnyx.net.Services.Connections.IPConnections;
using Xunit;

namespace TelnyxTests.Services.Connections.IPConnectionsTest
{
    public class IPConnectionServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly IPConnectionService service;
        private readonly ConnectionListOptions listOptions;
        private readonly UpsertIPConnectionOptions createOptions;

        public IPConnectionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new IPConnectionService();

            this.listOptions = null;
            this.createOptions = new UpsertIPConnectionOptions()
            {
                TransportProtocol = Telnyx.net.Entities.Enum.TransportProtocol.TLS
            };
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListIPConnections(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<IPConnection>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListIPConnectionsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<IPConnection>), message.GetType());
        }
        [Fact]
        public void Create()
        {
            var message = this.service.CreateIPConnection(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateIPConnectionAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }
        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteIPConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteIPConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }
        [Fact]
        public void Update()
        {
            var message = this.service.UpdateIPConnection(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateIPConnectionAsync(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveIPConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveIPConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IPConnection), message.GetType());
        }
    }
}
