using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Networking.Networks;
using Telnyx.net.Services.Networking;
using Xunit;

namespace TelnyxTests.Services.Networking
{
    public class NetworkInterfaceServiceTest : BaseTelnyxTest
    {
        private readonly NetworkInterfaceService service;
        private readonly NetworkInterfaceOption listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public NetworkInterfaceServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NetworkInterfaceService();

            this.listOptions = new NetworkInterfaceOption()
            {
                Status = "provisioned",
                Type = "wireguard_interface",
                Name = "test interface"
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NetworkInterface>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<NetworkInterface>), result.GetType());
        }
    }
}
