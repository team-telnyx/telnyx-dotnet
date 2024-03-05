using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.NumberBlockSearchService
{
    public class NumberBlockSearchServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly NumberBlockSearchServices service;
        private readonly NumberBlockSearchOptions listOptions;

        public NumberBlockSearchServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberBlockSearchServices();

            this.listOptions = new NumberBlockSearchOptions()
            {
            };
        }

        [Fact]
        public void List()
        {
            var list = this.service.List(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<AvailablePhoneNumberBlock>), list.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<AvailablePhoneNumberBlock>), list.GetType());
        }
    }
}
