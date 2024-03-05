using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign;
using Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.Campaigns.PartnerCampaign
{
    public class PartnerCampaignServiceTest : BaseTelnyxTest
    {
        private readonly PartnerCampaignSharingService service;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public PartnerCampaignServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PartnerCampaignSharingService();


            this.requestOptions = new RequestOptions();
        }

        public void Retrieve()
        {
            var message = this.service.Get(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PartnerCampaignSharing), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(PartnerCampaignSharing), message.GetType());
        }
    }
}
