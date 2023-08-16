namespace TelnyxTests.Services.PhoneNumbers.NumberConfigurations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Searches;
    using Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement;
    using Telnyx.net.Services.PhoneNumbers.RegulatoryRequirements;
    using Xunit;

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
                PhoneNumbers = new List<string>
                {
                    "+18665552368",
                },
            };
            this.listOptionsRegReq = new RegulatoryRequirementListOptions
            {
                RequirementId = null,
                FieldType = null,
                RequirementType = null,
            };
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public async Task ListAsync()
        {
            var response = await this.regService.GetRegulatoryRequirementsAsync(this.listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirement>), response.GetType());
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public void List()
        {
            var response = this.regService.GetRegulatoryRequirements(this.listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirement>), response.GetType());
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public void Get()
        {
            var response = this.regService.GetRegulatoryRequirementById(NumberOrderId, this.listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<RegulatoryRequirement>(response);
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public async Task GetAsync()
        {
            var response = await this.regService.GetRegulatoryRequirementByIdAsync(NumberOrderId, this.listOptionsRegReq);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders/12ade33a-21c0-473b-b055-b3c836e1c292");
            Assert.NotNull(response);
            Assert.IsType<RegulatoryRequirement>(response);
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public async Task ListPerPhoneAsync()
        {
            var response = await this.regPerPhoneService.GetRequirementsPerPhoneAsync(this.listOptionsPhoneNumberReg);
            //this.AssertRequest(HttpMethod.Post, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirementPerPhone>), response.GetType());
        }

        [Fact(Skip = "Mock response is incorrect body.")]
        public void ListPerPhone()
        {
            var response = this.regPerPhoneService.GetRequirementsPerPhone(this.listOptionsPhoneNumberReg);
            //this.AssertRequest(HttpMethod.Get, "/v2/number_orders");
            Assert.NotNull(response);
            Assert.Equal(typeof(TelnyxList<RegulatoryRequirementPerPhone>), response.GetType());
        }
    }
}
