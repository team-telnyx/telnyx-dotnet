namespace TelnyxTests.Services.Connections.FQDNSTests
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Requirements;
    using Telnyx.net.Services.Requirements;
    using Xunit;

    public class RequirementServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly RequirementService service;
        private readonly RequirementOption listOptions;

        public RequirementServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RequirementService();

            this.listOptions = new RequirementOption()
            {
                CountryCodeFilter = "Connection001",
                PhoneNumberTypeFilter = "Fqdn",
                ActionFilter = "1302",
                Sort = null
            };
        }

        [Fact]
        public void List()
        {
            var list = this.service.ListRequirement(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<Requirement>), list.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListRequirementAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<Requirement>), list.GetType());
        }

        [Fact]
        public void Get()
        {
            var message = this.service.GetRequirement(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Requirement), message.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var message = await this.service.GetRequirementAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Requirement), message.GetType());
        }
    }
}
