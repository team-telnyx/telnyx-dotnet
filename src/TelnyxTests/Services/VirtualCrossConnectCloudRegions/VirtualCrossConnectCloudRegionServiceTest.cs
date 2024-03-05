using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VirtualCrossConnectCloudRegions;
using Telnyx.net.Services.VirtualCrossConnectCloudRegions;
using Xunit;

namespace TelnyxTests.Services.VirtualCrossConnectCloudRegions
{
    public class VirtualCrossConnectCloudRegionServiceTest : BaseTelnyxTest
    {
        private readonly VirtualCrossConnectCloudRegionService service;
        private readonly VirtualCrossConnectCloudRegionOption listOptions;
        private readonly RequestOptions requestOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public VirtualCrossConnectCloudRegionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new VirtualCrossConnectCloudRegionService();

            this.listOptions = new VirtualCrossConnectCloudRegionOption()
            {
                RegionCode = "ashburn-va",
                CloudProvider = "aws"
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListVirtualCrossConnectCloudRegion(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VirtualCrossConnectCloudRegion>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListVirtualCrossConnectCloudRegionAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VirtualCrossConnectCloudRegion>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetVirtualCrossConnectCloudRegion(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnectCloudRegion), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetVirtualCrossConnectCloudRegionAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnectCloudRegion), message.GetType());
        }
    }
}
