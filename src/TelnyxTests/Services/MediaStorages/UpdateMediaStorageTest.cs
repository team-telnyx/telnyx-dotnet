using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.MediaStorages;
using Telnyx.net.Services.Documents;
using Telnyx.net.Services.WebRTC.Credentials;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.MediaStorages;
using System.Net.Mime;

namespace TelnyxTests.Services.Calls.ConferenceCommands.UpdateMediaStorage
{
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
            Assert.NotNull(result);
            Assert.Equal(typeof(MediaStorage), result.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateAsync(Id, this.UpdateMediaStorageOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(MediaStorage), result.GetType());
        }
    }
}

