namespace TelnyxTests.Services.Calls.CallControl.Refer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Services.Calls.CallControl.Refer;
    using Xunit;

    public class CallControlReferServiceTests : BaseTelnyxTest
    {
        private const string CallControllId = "call_123";

        private readonly CallControlReferService service;
        private readonly ReferOptions options;


        public CallControlReferServiceTests(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new CallControlReferService();

            this.options = new ReferOptions
            {
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = "891510ac-f3e4-11e8-af5b-de00688a4901",
                SIPAddress = "sip:example@telnyx",
                SIPAuthPassword = "Pass123",
                SIPAuthUserName = "testUser123",
                CustomHeaders = new List<CustomHeaders>
                {
                    new CustomHeaders
                    {
                        Value = "Test",
                        Name = "Test1",
                    },
                },
            };
        }

        [Fact]
        public async Task ReferAsync()
        {
            var response = await this.service.ReferAsync(CallControllId, this.options);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }

        [Fact]
        public void Refer()
        {
            var response = this.service.Refer(CallControllId, this.options);
            Assert.NotNull(response);
            Assert.IsType<TelnyxApiResponse>(response);
        }
    }
}
