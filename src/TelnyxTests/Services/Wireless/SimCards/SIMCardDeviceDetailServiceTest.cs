using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Wireless.SimCards;
using Telnyx.net.Services.Wireless.SimCards.SIMCardDeviceDetails;
using Xunit;

namespace TelnyxTests.Services.Wireless.SimCards
{
    public class SIMCardDeviceDetailServiceTest : BaseTelnyxTest
    {
        private readonly SIMCardDeviceDetailService service;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SIMCardDeviceDetailServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SIMCardDeviceDetailService();


            this.requestOptions = new RequestOptions();
        }

        public void Retrieve()
        {
            var message = this.service.Get(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(SIMCardDeviceDetail), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(SIMCardDeviceDetail), message.GetType());
        }
    }
}
