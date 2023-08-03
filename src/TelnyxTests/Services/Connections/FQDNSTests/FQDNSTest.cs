namespace TelnyxTests.Services.Connections.FQDNSTests
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.FQDNs;
    using Telnyx.net.Services.Connections.FQDNs;
    using Xunit;

    public class FQDNSTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly FQDNService service;
        private readonly FQDNListOptions listOptions;
        private readonly UpsertFQDNOptions createOptions;

        public FQDNSTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new FQDNService();

            this.listOptions = new FQDNListOptions()
            {
                ConnectionId = "Connection001",
                Fqdn = "Fqdn",
                Port = 1302,
                DNSRecordType = "DNSRecordType"
            };
            this.createOptions = new UpsertFQDNOptions()
            {
                ConnectionId = "Connection001",
                Fqdn = "example.com",
                Port = 1303,
                DNSRecordType = "DNSRecordType"
            };
        }

        [Fact]
        public void List()
        {
            var list = this.service.ListFQDNs(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<FQDN>), list.GetType());
            Assert.Collection(list, message => AssertResponse(message));
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListFQDNsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<FQDN>), list.GetType());
            Assert.Collection(list, message => AssertResponse(message));
        }

        [Fact]
        public void Create()
        {
            var message = this.service.CreateFQDNs(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateFQDNsAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteFQDNs(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteFQDNsAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateFQDNs(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateFQDNsAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveFQDNs(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveFQDNsAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        private static void AssertResponse(FQDN message)
        {
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
            Assert.Equal("1516447646313612565", message.ConnectionId);
            Assert.Equal("a", message.DnsRecordType);
            Assert.Equal("example.com", message.Fqdn);
            Assert.Equal("1293384261075731499", message.Id);
            Assert.Equal(5060, message.Port);
            Assert.Equal("a", message.DnsRecordType);
        }
    }
}
