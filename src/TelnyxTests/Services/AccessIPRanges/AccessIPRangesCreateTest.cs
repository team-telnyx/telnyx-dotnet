namespace TelnyxTests.Services.AccessToken
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.AccessIPRanges;
    using Telnyx.net.Entities.Enum.AccessIPRanges;
    using Telnyx.net.Services.AccessIPRange;
    using Xunit;

    /// <summary>
    /// Test class for AccessToken.
    /// </summary>
    public class AccessIPRangesCreateTest : BaseTelnyxTest
    {
        private readonly AcessIPRangesService service;
        private readonly AccessIPRangesCreateOption AccessIPRangesCreateOption;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AccessIPRangesCreateTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AcessIPRangesService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AccessIPRangesCreateOption = new AccessIPRangesCreateOption()
            {
                Description = "description",
                CidrBlock = "string",
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateAllAccessIPRanges(this.AccessIPRangesCreateOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPRanges), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            var items = result;
            Assert.Equal("string", items.CidrBlock);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.Description);
            Assert.Equal("string", items.Id);
            Assert.Equal(new CloudflareSyncStatus(), items.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.UserId);
        }

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAllAccessIPRangesAsync(this.AccessIPRangesCreateOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPRanges), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            var items = result;
            Assert.Equal("string", items.CidrBlock);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.Description);
            Assert.Equal("string", items.Id);
            Assert.Equal(new CloudflareSyncStatus(), items.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.UserId);
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteAllAccessIPRanges(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPRanges), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            var items = result;
            Assert.Equal("string", items.CidrBlock);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.Description);
            Assert.Equal("string", items.Id);
            Assert.Equal(new CloudflareSyncStatus(), items.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.UserId);
        }

        [Fact]
        public async Task DeleteSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteAllAccessIPRangesAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AccessIPRanges), result.GetType());
            var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
            var items = result;
            Assert.Equal("string", items.CidrBlock);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.Description);
            Assert.Equal("string", items.Id);
            Assert.Equal(new CloudflareSyncStatus(), items.Status);
            Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
            Assert.Equal("string", items.UserId);
        }
    }
}