namespace TelnyxTests.Services.Calls.CallControl.GatherStop
{
    using System;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Calls.CallControl.GatherStop;
    using Xunit;

    public class GatherStopServiceTests : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly GatherStopService service;
        private readonly GatherStopOptions options;


        public GatherStopServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new GatherStopService();

            this.options = new GatherStopOptions
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = Guid.Parse("891510ac-f3e4-11e8-af5b-de00688a4901"),
            };
        }

        [Fact]
        public async Task StopAsync()
        {
            var response = await this.service.StopAsync(CallControllId, this.options);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }

        [Fact]
        public void Stop()
        {
            var response = this.service.Stop(CallControllId, this.options);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }
    }
}
