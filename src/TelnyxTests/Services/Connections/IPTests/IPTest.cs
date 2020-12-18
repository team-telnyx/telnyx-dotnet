using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.IPs;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Services.Connections.IPs;
using Xunit;

namespace TelnyxTests.Services.Connections.IPTests
{
    public class IPTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly IPService service;
        private readonly IPListOptions listOptions;
        private readonly UpsertIPOptions createOptions;

        public IPTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new IPService();

            this.listOptions = new IPListOptions()
            {
                ConnectionId = "Connection001",
                IPAddress = "192.168.0.1",
                Port = 4455
            };
            this.createOptions = new UpsertIPOptions()
            {
                ConnectionId = "Connection001",
                IPAddress = "192.168.0.1",
                Port = 4455
            };
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListIPs(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<IP>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListIPsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<IP>), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var message = this.service.CreateIPs(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
            Assert.Equal(this.createOptions.IPAddress, message.IpAddress);
            Assert.Equal(this.createOptions.Port, message.Port);
            Assert.Equal(this.createOptions.ConnectionId, message.ConnectionId);
            Assert.Equal(RecordType.IP, message.RecordType);
            Assert.NotNull(message.Id);
            Assert.NotNull(message.CreatedAt);
            Assert.NotNull(message.UpdatedAt);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateIPsAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }
        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteIPs(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteIPsAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }
        [Fact]
        public void Update()
        {
            var message = this.service.UpdateIPs(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateIPsAsync(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveIPs(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveIPsAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
        }
    }
}
