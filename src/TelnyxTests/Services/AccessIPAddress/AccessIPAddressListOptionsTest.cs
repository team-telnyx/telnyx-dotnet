namespace TelnyxTests.Services.AccessIPAddressList
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AccessIPAddresses;
    using Telnyx.net.Entities.Enum.AccessIPAddresses;
    using Telnyx.net.Services.AccessIPAddresses;
    using Xunit;

    /// <summary>
    /// Test class for AccessIPAddressList.
    /// </summary>
    public class AccessIPAddressListTest : BaseTelnyxTest
    {
        private readonly AccessIPAddressService service;
        private readonly AccessIPAddressListOptions AccessIPAddressListOptions;
        private readonly UpsertAccessIPAddress AccessIPAddressCreateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AccessIPAddressListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AccessIPAddressService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AccessIPAddressListOptions = new AccessIPAddressListOptions()
            {
                IpSource = "string",
                IpAddress = "string",
                Status = Telnyx.net.Entities.Enum.AccessIPAddresses.CloudflareSyncStatus.Pending,
                CreatedAtGreaterThan = "string",
                CreatedAtLessThan = "string",
            };
            this.AccessIPAddressCreateOptions = new UpsertAccessIPAddress();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListAllAccessIPAddresses(this.AccessIPAddressListOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AccessIPAddress>), result.GetType());
            foreach (var item in result.Data)
            {
                var expectedDateTime = new DateTime(2024, 1, 23, 18, 10, 2, 574, DateTimeKind.Utc);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
                Assert.Equal("Description", item.Description);
                Assert.Equal("Id", item.Id);
                Assert.Equal("Ip Address", item.IpAddress);
                Assert.Equal("Source", item.Source);
                Assert.Equal(new CloudflareSyncStatus(), item.Status);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
                Assert.Equal("User Id", item.UserId);
            }
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAllAccessIPAddressesAsync(this.AccessIPAddressListOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AccessIPAddress>), result.GetType());
            foreach (var item in result.Data)
            {
                var expectedDateTime = new DateTime(2024, 1, 23, 18, 10, 2, 574, DateTimeKind.Utc);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
                Assert.Equal("Description", item.Description);
                Assert.Equal("Id", item.Id);
                Assert.Equal("Ip Address", item.IpAddress);
                Assert.Equal("Source", item.Source);
                Assert.Equal(new CloudflareSyncStatus(), item.Status);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
                Assert.Equal("User Id", item.UserId);
            }
        }

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveAllAccessIPAddresses(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var expectedDateTime = new DateTime(2024, 1, 23, 18, 10, 2, 574, DateTimeKind.Utc);
            var item = result;
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
            Assert.Equal("Description", item.Description);
            Assert.Equal("Id", item.Id);
            Assert.Equal("Ip Address", item.IpAddress);
            Assert.Equal("Source", item.Source);
            Assert.Equal(new CloudflareSyncStatus(), item.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("User Id", item.UserId);
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveAllAccessIPAddressesAsync(Id, this.baseOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var item = result;
            var expectedDateTime = new DateTime(2024, 1, 23, 18, 10, 2, 574, DateTimeKind.Utc);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
            Assert.Equal("Description", item.Description);
            Assert.Equal("Id", item.Id);
            Assert.Equal("Ip Address", item.IpAddress);
            Assert.Equal("Source", item.Source);
            Assert.Equal(new CloudflareSyncStatus(), item.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("User Id", item.UserId);
        }
    }
}