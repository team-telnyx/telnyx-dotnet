using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections;
using Telnyx.net.Services.Connections;
using Xunit;

namespace TelnyxTests.Services.Connections
{
    public class ConnectionActiveCallServiceTest : BaseTelnyxTest
    {
        private readonly ConnectionActiveCallService service;
        private readonly ConnectionActiveCallOption listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public ConnectionActiveCallServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConnectionActiveCallService();

            this.listOptions = new ConnectionActiveCallOption()
            {
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ConnectionActiveCall>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ConnectionActiveCall>), result.GetType());
        }
    }
}
