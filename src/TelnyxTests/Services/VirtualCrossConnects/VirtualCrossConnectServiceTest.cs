namespace TelnyxTests.Services.Reports.VirtualCrossConnects
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.VirtualCrossConnects;
    using Telnyx.net.Services.VirtualCrossConnects;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class VirtualCrossConnectServiceTest : BaseTelnyxTest
    {
        private readonly VirtualCrossConnectService service;
        private readonly VirtualCrossConnectOption listOptions;
        private readonly UpsertVirtualCrossConnect createOptions;
        private readonly UpdateVirtualCrossConnect updateOptions;
        private readonly RequestOptions requestOptions;

        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly string credConnId = "1234";
        public VirtualCrossConnectServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new VirtualCrossConnectService();

            this.listOptions = new VirtualCrossConnectOption()
            {
            };
            this.createOptions = new UpsertVirtualCrossConnect()
            {
                NetworkId = Guid.Parse("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                Name = "test interface",
                CloudProvider = "aws",
                CloudRegion = "us - east - 1",
                BgpAsn = 1234,
                BandwidthMbps = 50,
                PrimaryCloudAccountId = "123456789012",
                PrimaryTelnyxIp = "169.254.0.1",
                PrimaryCloudIp = "169.254.0.2",
                PrimaryBgpKey = "yFV4wEPtPVPfDUGLWiyQzwga",
                SecondaryCloudAccountId = "",
                SecondaryTelnyxIp = "169.254.0.3",
                SecondaryCloudIp = "169.254.0.4",
                SecondaryBgpKey = "ge1lONeK9RcA83uuWaw9DvZy",
                RegionCode = "ashburn - va"
            };
            this.updateOptions = new UpdateVirtualCrossConnect()
            {
                PrimaryEnabled = true,
                PrimaryRoutingAnnouncement = false,
                PrimaryCloudIp = "169.254.0.2",
                SecondaryEnabled = true,
                SecondaryRoutingAnnouncement = false,
                SecondaryCloudIp = "169.254.0.4"
            };

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListVirtualCrossConnect(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VirtualCrossConnect>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListVirtualCrossConnectAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<VirtualCrossConnect>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetVirtualCrossConnect(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetVirtualCrossConnectAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateVirtualCrossConnect(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(VirtualCrossConnect), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateVirtualCrossConnectAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(VirtualCrossConnect), result.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteVirtualCrossConnect(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteVirtualCrossConnectAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateVirtualCrossConnect(this.credConnId, this.updateOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateVirtualCrossConnectAsync(this.credConnId, this.updateOptions);
            Assert.NotNull(message);
            Assert.Equal(typeof(VirtualCrossConnect), message.GetType());
        }
    }
}