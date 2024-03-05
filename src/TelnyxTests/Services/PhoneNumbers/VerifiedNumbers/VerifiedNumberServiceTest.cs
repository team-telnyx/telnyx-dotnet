using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers;
using Telnyx.net.Services.PhoneNumbers.VerifiedNumbers;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.VerifiedNumbers
{
    public class VerifiedNumberServiceTest : BaseTelnyxTest
    {
        private readonly VerifiedNumberService service;
        private string Id;

        public VerifiedNumberServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new VerifiedNumberService();
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetVerifiedNumber(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetVerifiedNumberAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteVerifiedNumber(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteVerifiedNumberAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(VerifiedNumber), message.GetType());
        }
    }
}
