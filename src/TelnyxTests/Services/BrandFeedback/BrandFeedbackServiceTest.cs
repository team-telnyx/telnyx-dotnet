namespace TelnyxTests.Services.BrandFeedback
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Xunit;

    /// <summary>
    /// Test class for DetailRecord.
    /// </summary>
    public class BrandFeedbackServiceTest : BaseTelnyxTest
    {
        private readonly BrandFeedbackService service;
        private readonly BaseOptions baseOptions;

        private const string Id = "TAX_ID";

        public BrandFeedbackServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new BrandFeedbackService();
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.Get(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BrandFeedbackOptions), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(BrandFeedbackOptions), message.GetType());
        }
    }
}