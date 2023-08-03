namespace TelnyxTests.Services.Calls.CallControl.Transcriptions
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Enum.Transcriptions;
    using Telnyx.net.Services.Calls.CallControl.Transcriptions;
    using Xunit;

    public class TranscriptionServiceTests : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallTranscriptionService service;
        private readonly TranscriptionOptions stopOptions;
        private readonly TranscriptionStartOptions startOptions;

        public TranscriptionServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallTranscriptionService();

            this.stopOptions = new TranscriptionOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = "891510ac-f3e4-11e8-af5b-de00688a4901",
            };
            this.startOptions = new TranscriptionStartOptions
            {
                ClientState = this.stopOptions.ClientState,
                CommandId = this.stopOptions.CommandId,
                Language = Languages.English
            };
        }

        [Fact]
        public async Task StartAsync()
        {
            var response = await this.service.StartAsync(CallControllId, this.startOptions);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }

        [Fact]
        public void Start()
        {
            var response = this.service.Start(CallControllId, this.startOptions);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }

        [Fact]
        public async Task StopAsync()
        {
            var response = await this.service.StopAsync(CallControllId, this.stopOptions);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }

        [Fact]
        public void Stop()
        {
            var response = this.service.Stop(CallControllId, this.stopOptions);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }
    }
}
