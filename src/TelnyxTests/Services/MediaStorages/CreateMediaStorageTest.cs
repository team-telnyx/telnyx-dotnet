using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.MediaStorages;
using Telnyx.net.Services.Documents;
using Telnyx.net.Services.WebRTC.Credentials;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.MediaStorages;

namespace TelnyxTests.Services.Calls.ConferenceCommands.CreateMediaStorage
{
    /// <summary>
    /// Test class for CreateMediaStorage.
    /// </summary>
    public class MediaStorageList : BaseTelnyxTest
    {
        private readonly MediaStorageService service;
        private readonly CreateMediaStorageOptions CreateMediaStorageOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public MediaStorageList(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MediaStorageService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.CreateMediaStorageOptions = new CreateMediaStorageOptions()
            {
                MediaName = "my-file",
                MediaUrl = "http://www.example.com/audio.mp3",
                TtlSeconds = 86400,

            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateMediaStorage(this.CreateMediaStorageOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MediaStorage), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateMediaStorageAsync(this.CreateMediaStorageOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(MediaStorage), result.GetType());
        }
    }
}




