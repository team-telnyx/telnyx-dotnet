namespace TelnyxTests.Services.ShortCodes
{
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.ShortCode;
    using Telnyx.net.Services.ShortCode;
    using Xunit;

    public class ShortCodeSeviceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private readonly ShortCodeService service;
        private readonly ShortCodeOption listOptions;
        private readonly UpsertShortCode createOptions;

        public ShortCodeSeviceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ShortCodeService();

            this.listOptions = new ShortCodeOption()
            {
                MessagingProfileId = "4001767e-82b1-450f-9c9e-9512e5d3a7de"
            };
            this.createOptions = new UpsertShortCode()
            {
                MessagingProfileId = "4001767e-82b1-450f-9c9e-9512e5d3a7de"
            };
        }

        [Fact]
        public void List()
        {
            var list = this.service.ListShortCodes(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<ShortCodes>), list.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var list = await this.service.ListShortCodesAsync(this.listOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(list);
            Assert.Equal(typeof(TelnyxList<ShortCodes>), list.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.UpdateShortCodes(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ShortCodes), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateShortCodesAsync(this.credConnId, this.createOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ShortCodes), message.GetType());
        }

        [Fact]
        public void Get()
        {
            var message = this.service.GetShortCodes(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ShortCodes), message.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var message = await this.service.GetShortCodesAsync(this.credConnId);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ShortCodes), message.GetType());
        }

    }
}
