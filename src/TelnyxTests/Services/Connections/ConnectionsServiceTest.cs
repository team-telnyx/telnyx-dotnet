namespace TelnyxTests.Services.Connections
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Services.Connections;
    using Xunit;

    public class ConnectionsServiceTest : BaseTelnyxTest
    {
        private readonly ConnectionService service;
        private readonly ConnectionListOptions listOptions;
        private readonly string connectionServiceId = "Id123";

        public ConnectionsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConnectionService();

            this.listOptions = null;
        }

        [Fact]
        public void List()
        {
            var message = this.service.ListConnections(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<Connection>), message.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var message = await this.service.ListConnectionsAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(TelnyxList<Connection>), message.GetType());
        }

        [Fact]
        public void RetrieveConnection()
        {
            var message = this.service.RetrieveConnection(this.connectionServiceId);
            Assert.NotNull(message);
            Assert.Equal(typeof(Connection), message.GetType());
            Assert.Equal(RecordType.IPConnection, message.RecordType);
            Assert.NotNull(message.ConnectionName);
            Assert.NotNull(message.Id);
            Assert.NotNull(message.Active);
            Assert.NotNull(message.CreatedAt);
            Assert.NotNull(message.UpdatedAt);
            Assert.NotNull(message.OutboundVoiceProfileId);
            Assert.NotNull(message.WebhookEventFailoverUrl);
            Assert.NotNull(message.WebhookEventUrl);
        }

        [Fact]
        public async Task RetrieveConnectionAsync()
        {
            var message = await this.service.RetrieveConnectionAsync(this.connectionServiceId);
            Assert.NotNull(message);
            Assert.Equal(typeof(Connection), message.GetType());
            Assert.Equal(RecordType.IPConnection, message.RecordType);
            Assert.NotNull(message.ConnectionName);
            Assert.NotNull(message.Id);
            Assert.NotNull(message.Active);
            Assert.NotNull(message.CreatedAt);
            Assert.NotNull(message.UpdatedAt);
            Assert.NotNull(message.OutboundVoiceProfileId);
            Assert.NotNull(message.WebhookEventFailoverUrl);
            Assert.NotNull(message.WebhookEventUrl);
        }
    }
}

