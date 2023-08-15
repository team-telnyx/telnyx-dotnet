namespace TelnyxTests.Services.Calls.ConferenceCommands.ConferenceStop
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Calls.ConferenceCommands.ConferenceStop;
    using Telnyx.net.Services.Documents;
    using Telnyx.net.Services.WebRTC.Credentials;
    using Xunit;

    /// <summary>
    /// Test class for ConferenceStop.
    /// </summary>
    public class ConferenceStopTest : BaseTelnyxTest
    {
        private readonly ConferenceStopService service;
        private readonly StopAudioOptions stopOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private readonly DocumentCreateOptions createOptions;
        private readonly TelephonyCredentialUpdateOptions updateOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public ConferenceStopTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ConferenceStopService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.stopOptions = new StopAudioOptions()
            {
                CallControlIds = new string[] { "string1", "string2", "string3" },
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Stop(Id, this.stopOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
            Assert.Equal("ok", result.Result);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.StopAsync(Id, this.stopOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
            Assert.Equal("ok", result.Result);
        }
    }
}
