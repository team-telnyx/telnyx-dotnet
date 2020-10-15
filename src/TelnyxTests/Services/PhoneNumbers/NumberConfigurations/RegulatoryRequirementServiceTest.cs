using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.Searches;
using Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement;
using Telnyx.net.Services.PhoneNumbers.RegulatoryRequirements;
using Xunit;

namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
    public class RegulatoryRequirementServiceTest : BaseTelnyxTest
    {
        private const string NumberOrderId = "12ade33a-21c0-473b-b055-b3c836e1c292";

        private readonly RegulatoryRequirementService regService;
        private readonly PhoneNumberRegulatoryRequirementService regPerPhoneService;

        private readonly PhoneNumberRegulatoryRequirementListOptions listOptionsPhoneNumberReg;
        private readonly RegulatoryRequirementListOptions listOptionsRegReq;



        public RegulatoryRequirementServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.regService = new RegulatoryRequirementService();
            this.regPerPhoneService = new PhoneNumberRegulatoryRequirementService();
            this.listOptionsPhoneNumberReg = new PhoneNumberRegulatoryRequirementListOptions
            {
                PhoneNumbers = null
            };
            this.listOptionsRegReq = new RegulatoryRequirementListOptions
            {
                RequirementId = null,
                FieldType = null,
                RequirementType = null
            };

        }

        [Fact]
        public async Task ListAsync()
        {
            var response = await this.regService.GetRegulatoryRequirementsAsync(listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirement>), response.GetType());
        }
        [Fact]
        public void List()
        {
            var response = this.regService.GetRegulatoryRequirements(listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirement>), response.GetType());
        }

        [Fact]
        public void Get()
        {
            var response = this.regService.GetRegulatoryRequirementById(NumberOrderId, listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<RegulatoryRequirement>(response);
        }

        [Fact]
        public async Task GetAsync()
        {
            var response = await this.regService.GetRegulatoryRequirementByIdAsync(NumberOrderId, listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<RegulatoryRequirement>(response);
        }
        [Fact]
        public async Task ListPerPhoneAsync()
        {
            var response = await this.regPerPhoneService.GetRequirementsPerPhoneAsync(listOptionsPhoneNumberReg);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirementPerPhone>), response.GetType());
        }
        [Fact]
        public void ListPerPhone()
        {
            var response = this.regPerPhoneService.GetRequirementsPerPhone(listOptionsPhoneNumberReg);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirementPerPhone>), response.GetType());
        }

    }
}
