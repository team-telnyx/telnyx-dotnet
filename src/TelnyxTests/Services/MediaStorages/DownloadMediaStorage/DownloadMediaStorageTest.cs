//using System.Threading.Tasks;
//using Telnyx;
//using Telnyx.net.Entities;
//using Telnyx.net.Services.MediaStorages;
//using Telnyx.net.Services.Documents;
//using Telnyx.net.Services.WebRTC.Credentials;
//using Xunit;
//using System.Threading;
//using Telnyx.net.Entities.MediaStorages;
//using System.Net.Mime;

//namespace TelnyxTests.Services.Calls.ConferenceCommands.DownloadMediaStorage
//{
//    /// <summary>
//    /// Test class for DownloadMediaStorage.
//    /// </summary>
//    public class DownloadMediaStorageTest : BaseTelnyxTest
//    {
//        private readonly MediaStorageService service;
//        private readonly MediaStorageListOptions MediaStorageListOptions;
//        private readonly RequestOptions requestOptions;
//        private readonly BaseOptions baseOptions;
//        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

//        public DownloadMediaStorageTest(MockHttpClientFixture mockHttpClientFixture)
//            : base(mockHttpClientFixture)
//        {
//            this.service = new MediaStorageService();
//            this.baseOptions = new BaseOptions();
//            this.requestOptions = new RequestOptions();
//            this.MediaStorageListOptions = new MediaStorageListOptions()
//            {
//                ContentType = "application_xml",

//            };
//        }

//        [Fact]
//        public void List()
//        {
//            var result = this.service.ListMediaStorages(this.MediaStorageListOptions, this.requestOptions);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(MediaStorage), result.GetType());
//            foreach (var item in result.Data)
//            {
//                Assert.Equal("application/xml", item.ContentType);
//                Assert.Equal("2019-01-23T18:10:02.574Z", item.CreatedAt);
//                Assert.Equal("2020-01-23T18:10:02.574Z", item.ExpiresAt);
//                Assert.Equal("f5586561-8ff0-4291-a0ac-84fe544797bd", item.MediaName);
//                Assert.Equal("2019-01-23T18:10:02.574Z", item.UpdatedAt);
//            }
//        }

//        [Fact]
//        public async Task ListAsync()
//        {
//            var cts = new CancellationTokenSource();
//            var result = await this.service.ListMediaStoragesAsync(this.MediaStorageListOptions, this.requestOptions, cts.Token);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(MediaStorage), result.GetType());
//            foreach (var item in result.Data)
//            {
//                Assert.Equal("application/xml", item.ContentType);
//                Assert.Equal("2019-01-23T18:10:02.574Z", item.CreatedAt);
//                Assert.Equal("2020-01-23T18:10:02.574Z", item.ExpiresAt);
//                Assert.Equal("f5586561-8ff0-4291-a0ac-84fe544797bd", item.MediaName);
//                Assert.Equal("2019-01-23T18:10:02.574Z", item.UpdatedAt);
//            }
//        }
//    }
//}

