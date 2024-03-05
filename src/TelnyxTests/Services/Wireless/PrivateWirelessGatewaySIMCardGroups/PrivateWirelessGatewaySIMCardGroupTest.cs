using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Wireless.PrivateWirelessGatewaySIMCardGroups;
using Telnyx.net.Services.Wireless.PrivateWirelessGatewaySIMCardGroups;
using Xunit;

namespace TelnyxTests.Services.Wireless.PrivateWirelessGatewaySIMCardGroups
{
    public class PrivateWirelessGatewaySIMCardGroupTest : BaseTelnyxTest
    {
        private readonly PrivateWirelessGatewaySIMCardGroupService service;
        private readonly UpsertPrivateWirelessGatewaySIMCardGroup createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public PrivateWirelessGatewaySIMCardGroupTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PrivateWirelessGatewaySIMCardGroupService();

            this.createOptions = new UpsertPrivateWirelessGatewaySIMCardGroup()
            {
                PrivateWirelessGatewayId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58")
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(PrivateWirelessGatewaySIMCardGroup), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(PrivateWirelessGatewaySIMCardGroup), result.GetType());
        }
    }
}
