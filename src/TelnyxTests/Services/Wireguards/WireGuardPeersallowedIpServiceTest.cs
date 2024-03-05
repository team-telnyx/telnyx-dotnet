using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.WireGuardPeersallowedIps;
using Telnyx.net.Services.PhoneNumbers.WireGuardPeersallowedIps;
using Xunit;

namespace TelnyxTests.Services.Wireguards
{
    public class WireGuardPeersallowedIpServiceTest : BaseTelnyxTest
    {
        private readonly WireGuardPeersallowedIpService service;
        private readonly WireGuardPeersAllowedIpOption listOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public WireGuardPeersallowedIpServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new WireGuardPeersallowedIpService();

            this.listOptions = new WireGuardPeersAllowedIpOption()
            {
            };

        }

        [Fact]
        public void List()
        {
            var result = this.service.List(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardPeersAllowedIp>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<WireGuardPeersAllowedIp>), result.GetType());
        }
    }
}
