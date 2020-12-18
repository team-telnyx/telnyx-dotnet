using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.FQDNConnections;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Services.Connections;
using Telnyx.net.Services.Connections.FQDNConnections;
using Xunit;

namespace TelnyxTests.Services.Connections.FQDNConnectionsTest
{
    public class FQDNConnectionServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly FQDNConnectionService service;
        private readonly ConnectionListOptions listOptions;
        private readonly UpsertFQDNConnectionOptions createOptions;

        public FQDNConnectionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new FQDNConnectionService();

            this.listOptions = null;
            this.createOptions = new UpsertFQDNConnectionOptions()
            {
                TransportProtocol = Telnyx.net.Entities.Enum.TransportProtocol.TCP,
                ConnectionName = "Test Name"
            };
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListFQDNConnection(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<FQDNConnection>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListFQDNConnectionAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<FQDNConnection>), message.GetType());
        }
        [Fact]
        public void Create()
        {
            var message = this.service.CreateFQDNConnection(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateFQDNConnectionAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
            Assert.Equal(this.createOptions.OnnetT38PassthroughEnabled, message.OnnetT38PassthroughEnabled);
            Assert.Equal(RecordType.FQDNConnection, message.RecordType);
            Assert.NotNull(message.Id);
            Assert.NotNull(message.RtcpSettings);
            Assert.NotNull(message.TransportProtocol);
            Assert.NotNull(message.CreatedAt);
            Assert.NotNull(message.UpdatedAt);
            Assert.NotNull(message.AnchorsiteOverride);
            Assert.NotNull(message.ConnectionName);
            Assert.NotNull(message.EncryptedMedia);
            Assert.NotNull(message.DtmfType);

        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteFQDNConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteFQDNConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }
        [Fact]
        public void Update()
        {
            var message = this.service.UpdateFQDNConnection(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateFQDNConnectionAsync(credConnId, createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }
        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveFQDNConnection(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveFQDNConnectionAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(FQDNConnection), message.GetType());
        }
    }
}
