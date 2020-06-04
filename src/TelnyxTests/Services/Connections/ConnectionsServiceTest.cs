using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections.ConnectionsService;
using Telnyx.net.Entities.Enum.Connections;
using Telnyx.net.Services.Connections;
using Xunit;

namespace TelnyxTests.Services.Connections
{
    public class ConnectionsServiceTest : BaseTelnyxTest
    {

        private readonly ConnectionService service;
        private readonly ConnectionListOptions listOptions;

        public ConnectionsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConnectionService();

            this.listOptions = new ConnectionListOptions()
            {
                Sort = ConnectionSort.CreatedAtDESC
            };
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
    }
}

