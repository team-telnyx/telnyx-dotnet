using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles;
using Telnyx.net.Services.PhoneNumbers.PhoneNumberAssignmentByProfiles;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.PhoneNumberAssignmentByProfiles
{
    public class PhoneNumberAssignmentByProfileServiceTest : BaseTelnyxTest
    {
        private readonly PhoneNumberAssignmentByProfileService service;
        private readonly string credConnId = "1234";

        public PhoneNumberAssignmentByProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PhoneNumberAssignmentByProfileService();
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetPhoneNumberAssignmentByProfile(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PhoneNumberAssignmentByProfile), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetPhoneNumberAssignmentByProfileAsync(credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PhoneNumberAssignmentByProfile), message.GetType());
        }
    }
}
