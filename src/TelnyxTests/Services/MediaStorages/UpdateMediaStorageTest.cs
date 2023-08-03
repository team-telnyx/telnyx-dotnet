namespace TelnyxTests.Services.Calls.ConferenceCommands.UpdateMediaStorage
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.MediaStorages;
    using Telnyx.net.Services.MediaStorages;
    using Xunit;

    /// <summary>
    /// Test class for UpdateMediaStorage.
    /// </summary>
    public class UpdateMediaStorageTest : BaseTelnyxTest
    {
        private readonly MediaStorageService service;
        private readonly UpdateMediaStorageOptions UpdateMediaStorageOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public UpdateMediaStorageTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MediaStorageService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.UpdateMediaStorageOptions = new UpdateMediaStorageOptions()
            {
                MediaUrl = "http://www.example.com/audio.mp3",
                TtlSeconds = 86400,
            };
        }

        [Fact]
        public void Update()
        {
            var result = this.service.Update(Id, this.UpdateMediaStorageOptions, this.requestOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateAsync(Id, this.UpdateMediaStorageOptions, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        private static void AssertResponse(MediaStorage result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(MediaStorage), result.GetType());
            Assert.Equal("application/xml", result.ContentType);
            Assert.Equal("2019-01-23T18:10:02.574Z", result.CreatedAt);
            Assert.Equal("2020-01-23T18:10:02.574Z", result.ExpiresAt);
            Assert.Equal("f5586561-8ff0-4291-a0ac-84fe544797bd", result.MediaName);
            Assert.Equal("2019-01-23T18:10:02.574Z", result.UpdatedAt);
        }
    }
}

