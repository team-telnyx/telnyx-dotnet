using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.CredentialConnections;
using Telnyx.net.Entities.Enum.Connections;
using Telnyx.net.Services.Connections.CredentialConnections;
using Telnyx.net.Services.Connections.Options;
using Xunit;

namespace TelnyxTests.Services.Connections.CredentialConnections
{
    public class CredentialConnectionServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly CredentialConnectionService service;
        private readonly ConnectionListOptions listOptions;
        private readonly CreateCredConnectionOptions createOptions;

        public CredentialConnectionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CredentialConnectionService();

            this.listOptions = new ConnectionListOptions()
            {
                Sort = ConnectionSort.CreatedAtDESC
            };
            this.createOptions = new CreateCredConnectionOptions
            {

            };
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListCredentialConnection(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CredentialConnection>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListCredentialConnectionAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<CredentialConnection>), message.GetType());
        }
        [Fact]
        public void Create()
        {
            var message = this.service.CreateCredentialConnection(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateCredentialConnectionAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }
        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteCredentialConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteCredentialConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }
        [Fact]
        public void Update()
        {
            var message = this.service.UpdateCredentialConnection(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateCredentialConnectionAsync(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveCredentialConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveCredentialConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
        }
    }
}
