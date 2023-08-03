namespace TelnyxTests.Services.Connections.CredentialConnections
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.CredentialConnections;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Enum.Connections;
    using Telnyx.net.Services.Connections;
    using Telnyx.net.Services.Connections.CredentialConnections;
    using Xunit;

    public class CredentialConnectionServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly CredentialConnectionService service;
        private readonly ConnectionListOptions listOptions;
        private readonly UpsertCredentialConnectionOptions createOptions;

        public CredentialConnectionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CredentialConnectionService();

            this.listOptions = null;
            this.createOptions = new UpsertCredentialConnectionOptions()
            {
                SipUriCallingPreference = "disabled",
                UserName = "user001",
                Outbound = null,
                Password = "pwd001",
                ConnectionName = "name"
            };
        }

        [Fact]
        public void List()
        {
            var list = this.service.ListCredentialConnection(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<CredentialConnection>), list.GetType());
            Assert.Collection(list.Data, message =>
            {
                AssertResponse(message);
            });
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListCredentialConnectionAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<CredentialConnection>), list.GetType());
            Assert.Collection(list.Data, message =>
            {
                AssertResponse(message);
            });
        }

        [Fact]
        public void Create()
        {
            var message = this.service.CreateCredentialConnection(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateCredentialConnectionAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteCredentialConnection(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteCredentialConnectionAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateCredentialConnection(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateCredentialConnectionAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.RetrieveCredentialConnection(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.RetrieveCredentialConnectionAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            AssertResponse(message);
        }

        private static void AssertResponse(CredentialConnection message)
        {
            Assert.NotNull(message);
            Assert.Equal(typeof(CredentialConnection), message.GetType());
            Assert.Equal("6a09cdc3-8948-47f0-aa62-74ac943d6c58", message.Id);
            Assert.Equal(RecordType.CredentialConnection, message.RecordType);
            Assert.True(message.Active);
            Assert.Equal("myusername123", message.UserName);
            Assert.Equal("my123secure456password789", message.Password);
            Assert.NotNull( message.CreatedAt.Value.ToString());
            Assert.NotNull( message.UpdatedAt.Value.ToString());
            Assert.Equal(AnchorsiteOverride.Latency, message.AnchorsiteOverride);
            Assert.Equal("string", message.ConnectionName);
            Assert.Equal("disabled", message.SipUriCallingPreference);
            Assert.True(message.DefaultOnHoldComfortNoiseEnabled);
            Assert.Equal(DTMFType.RFC_2833, message.DtmfType);
            Assert.True(message.EncodeContactHeaderEnabled);
            Assert.Equal(EncryptedMedia.SRTP, message.EncryptedMedia);
        }
    }
}
