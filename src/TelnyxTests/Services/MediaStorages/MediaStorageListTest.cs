namespace TelnyxTests.Services.Calls.ConferenceCommands.MediaStorageList
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.MediaStorages;
    using Telnyx.net.Services.MediaStorages;
    using Xunit;

    /// <summary>
    /// Test class for MediaStorageList.
    /// </summary>
    public class MediaStorageListTest : BaseTelnyxTest
    {
        private readonly MediaStorageService service;
        private readonly MediaStorageListOptions MediaStorageListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public MediaStorageListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MediaStorageService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.MediaStorageListOptions = new MediaStorageListOptions()
            {
                ContentType = "application_xml",
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListMediaStorages(this.MediaStorageListOptions, this.requestOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListMediaStoragesAsync(this.MediaStorageListOptions, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        private static void AssertResponse(TelnyxList<MediaStorage> result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<MediaStorage>), result.GetType());
            foreach (var item in result.Data)
            {
                Assert.Equal("application/xml", item.ContentType);
                Assert.Equal("01/23/2019 18:10:02", item.CreatedAt);
                Assert.Equal("01/23/2020 18:10:02", item.ExpiresAt);
                Assert.Equal("f5586561-8ff0-4291-a0ac-84fe544797bd", item.MediaName);
                Assert.Equal("01/23/2019 18:10:02", item.UpdatedAt);
            }
        }
    }
}

