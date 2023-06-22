using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Calls.CallControl.ClientState;
using Telnyx.net.Services.Calls.CallControl.ClientState;
using Xunit;

namespace TelnyxTests.Services.Calls.CallControl.ClientState
{
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
            var response = this.service.UpdateEntity(CallControllId,this.options);
            Assert.NotNull(response);
            var result = response.Result;
            Assert.Equal(typeof(ClientStateOption), result.GetType());
            Assert.Equal("ok", result);

        }
        [Fact]
        public async Task UpdateAsync()
        {
            var response = await this.service.UpdateEntityAsync(CallControllId, this.options);
            Assert.NotNull(response);
            var result = response.Result;
            Assert.Equal(typeof(ClientStateOption), result.GetType());
        }
    }
}
