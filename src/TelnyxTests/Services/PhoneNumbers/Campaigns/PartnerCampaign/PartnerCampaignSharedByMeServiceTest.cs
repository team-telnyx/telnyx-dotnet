using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign;
using Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.PartnerCampaign
{
    public class PartnerCampaignSharedByMeServiceTest : BaseTelnyxTest
    {
        private readonly PartnerCampaignSharedByMeService service;
        private readonly PartnerCampaignSharedByMeOption listOptions;
        private readonly RequestOptions requestOptions;

        public PartnerCampaignSharedByMeServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new PartnerCampaignSharedByMeService();
            this.requestOptions = new RequestOptions();
            this.listOptions = new PartnerCampaignSharedByMeOption()
            {
                Page = 1,
                RecordsPerPage = 10
            };
        }
        [Fact]
        public void List()
        {
            var result = this.service.ListPartnerCampaignSharedByMe(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PartnerCampaignSharedByMe>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListPartnerCampaignSharedByMeAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<PartnerCampaignSharedByMe>), result.GetType());
        }
    }
}
