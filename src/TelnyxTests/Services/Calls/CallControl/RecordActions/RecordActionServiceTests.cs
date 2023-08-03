namespace TelnyxTests.Services.Calls.CallControl.RecordActions
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Calls.CallControl.RecordActions;
    using Xunit;

    public class RecordActionServiceTests : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly RecordActionService service;
        private readonly RecordStartOptions createOptions;
        private readonly RecordActionOptions options;


        public RecordActionServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RecordActionService();

            this.createOptions = new RecordStartOptions()
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                Channels = RecordStartOptions.ChannelEnum.DualEnum,
                Format = RecordStartOptions.FormatEnum.Mp3Enum,
                PlayBeep = false,
            };

            this.options = new RecordActionOptions
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new System.Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
            };
        }

        [Fact]
        public void Start()
        {
            var message = this.service.Start(CallControllId, this.createOptions);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public async Task StartAsync()
        {
            var message = await this.service.StartAsync(CallControllId, this.createOptions);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public void Stop()
        {
            var message = this.service.Stop(CallControllId, this.options);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public async Task StopAsync()
        {
            var message = await this.service.StopAsync(CallControllId, this.options);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public void Pause()
        {
            var message = this.service.Pause(CallControllId, this.options);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public async Task PauseAsync()
        {
            var message = await this.service.PauseAsync(CallControllId, this.options);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public void Resume()
        {
            var message = this.service.Resume(CallControllId, this.options);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }

        [Fact]
        public async Task ResumeAsync()
        {
            var message = await this.service.ResumeAsync(CallControllId, this.createOptions);
            Assert.NotNull(message);
            Assert.IsType<TelnyxApiResponse>(message);
        }
    }
}
