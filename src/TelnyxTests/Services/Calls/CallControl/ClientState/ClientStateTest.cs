namespace TelnyxTests.Services.Calls.CallControl.ClientState
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Calls.CallControl.ClientState;
    using Telnyx.net.Services.Calls.CallControl.ClientState;
    using Xunit;

    public class CallControlReferServiceTests : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly ClientStateService service;
        private readonly ClientStateOption options;


        public CallControlReferServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ClientStateService();

            this.options = new ClientStateOption
            {
                ClientStates = "aGF2ZSBhIG5pY2UgZGF5ID1d",
            };
        }

        [Fact]
        public void Update()
        {
            var response = this.service.Upgrade(CallControllId, this.options);
            Assert.NotNull(response);
            var result = response.Result;
            Assert.Equal(typeof(TelnyxApiResponse), response.GetType());
            Assert.Equal("ok", result);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpgradeAsync(CallControllId, this.options);
            Assert.NotNull(response);
            var result = response.Result;
            Assert.Equal(typeof(TelnyxApiResponse), response.GetType());
            Assert.Equal("ok", result);
        }
    }
}
