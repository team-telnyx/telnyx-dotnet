namespace TelnyxTests.Services.AccessToken
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AccessIPRanges;
    using Telnyx.net.Entities.Enum.AccessIPRanges;
    using Telnyx.net.Services.AccessIPRange;
    using Xunit;

    /// <summary>
    /// Test class for AccessToken.
    /// </summary>
    public class AccessIPRangesListTest : BaseTelnyxTest
    {
        private readonly AcessIPRangesService service;
        private readonly AccessIPRangesListOption AccessIPRangesListOption;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AccessIPRangesListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AcessIPRangesService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AccessIPRangesListOption = new AccessIPRangesListOption()
            {
                CidrBlock = "string",
                CidrBlockContains = "string",
                Status = Telnyx.net.Entities.Enum.AccessIPRanges.CloudflareSyncStatus.Pending,
                CreatedAtGreaterThan = DateTime.UtcNow,
                CidrBlockEndsWith = "string",
                CidrBlockStartsWith = "string",
                CreatedAtLessThan = DateTime.UtcNow,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListAllAccessIPRanges(this.AccessIPRangesListOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AccessIPRanges>), result.GetType());
            foreach (var items in result.Data)
            {
                var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
                Assert.Equal("string", items.CidrBlock);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
                Assert.Equal("string", items.Description);
                Assert.Equal("string", items.Id);
                Assert.Equal(new CloudflareSyncStatus(), items.Status);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
                Assert.Equal("string", items.UserId);
            }
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAllAccessIPRangesAsync(this.AccessIPRangesListOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AccessIPRanges>), result.GetType());
            foreach (var items in result.Data)
            {
                var expectedDateTime = new DateTime(2019, 8, 24, 14, 15, 22);
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
}