using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.FQDNs;
using Telnyx.net.Services.Connections;
using Telnyx.net.Services.Connections.FQDNs;
using Xunit;

namespace TelnyxTests.Services.Connections.FQDNSTests
{
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

            this.listOptions = new FQDNListOptions();
            this.createOptions = new UpsertFQDNOptions();
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListFQDNs(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<FQDN>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListFQDNsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<FQDN>), message.GetType());
        }
        [Fact]
        public void Create()
        {
            var message = this.service.CreateFQDNs(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateFQDNsAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }
        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteFQDNs(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteFQDNsAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }
        [Fact]
        public void Update()
        {
            var message = this.service.UpdateFQDNs(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateFQDNsAsync(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveFQDNs(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveFQDNsAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDN), message.GetType());
        }
    }
}
