namespace TelnyxTests.Services.AccessIPAddressCreate
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.AccessIPAddresses;
    using Telnyx.net.Entities.Enum.AccessIPAddresses;
    using Telnyx.net.Services.AccessIPAddresses;
    using Xunit;

    /// <summary>
    /// Test class for AccessIPAddressCreate.
    /// </summary>
    public class AccessIPAddressCreateTest : BaseTelnyxTest
    {
        private readonly AccessIPAddressService service;
        private readonly AccessIPAddressCreateOptions AccessIPAddressCreateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private readonly string json;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AccessIPAddressCreateTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AccessIPAddressService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AccessIPAddressCreateOptions = new AccessIPAddressCreateOptions()
            {
                Description = "description",
                IpAddress = "string",
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateAllAccessIPAddresses(this.AccessIPAddressCreateOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", result.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", result.Description);
            Assert.Equal("string", result.Id);
            Assert.Equal("string", result.IpAddress);
            Assert.Equal("string", result.Source);
            Assert.Equal(new CloudflareSyncStatus(), result.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", result.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", result.UserId);
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAllAccessIPAddressesAsync(this.AccessIPAddressCreateOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", result.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", result.Description);
            Assert.Equal("string", result.Id);
            Assert.Equal("string", result.IpAddress);
            Assert.Equal("string", result.Source);
            Assert.Equal(new CloudflareSyncStatus(), result.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", result.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", result.UserId);
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteAllAccessIPAddresses(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            var item = result;
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", item.Description);
            Assert.Equal("string", item.Id);
            Assert.Equal("string", item.IpAddress);
            Assert.Equal("string", item.Source);
            Assert.Equal(new CloudflareSyncStatus(), item.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", item.UserId);
        }

        [Fact]
        public async Task DeleteSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteAllAccessIPAddressesAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPAddress), result.GetType());
            var item = result;
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", item.Description);
            Assert.Equal("string", item.Id);
            Assert.Equal("string", item.IpAddress);
            Assert.Equal("string", item.Source);
            Assert.Equal(new CloudflareSyncStatus(), item.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", item.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", item.UserId);
        }
    }
}