namespace TelnyxTests.Services.Connections.IPTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.IPs;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Services.Connections.IPs;
    using Xunit;

    public class IPTest : BaseTelnyxTest
    {
        private readonly string credConnId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
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
            var list = this.service.ListIPs(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<IP>), list.GetType());
            Assert.Collection(list, message => AssertResponse(message));
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListIPsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<IP>), list.GetType());
            Assert.Collection(list, message => AssertResponse(message));
        }

        [Fact]
        public void Create()
        {
            var message = this.service.CreateIPs(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateIPsAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteIPs(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteIPsAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateIPs(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateIPsAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveIPs(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveIPsAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        private static void AssertResponse(IP message)
        {
            Assert.NotNull(message);
            Assert.Equal(typeof(IP), message.GetType());
            Assert.Equal("192.168.0.0", message.IpAddress);
            Assert.Equal(5060, message.Port);
            Assert.Equal("3456789987654", message.ConnectionId);
            Assert.Equal(RecordType.IP, message.RecordType);
            Assert.Equal("6a09cdc3-8948-47f0-aa62-74ac943d6c58", message.Id);
            Assert.NotNull(message.CreatedAt);
            Assert.NotNull(message.UpdatedAt);
        }
    }
}
