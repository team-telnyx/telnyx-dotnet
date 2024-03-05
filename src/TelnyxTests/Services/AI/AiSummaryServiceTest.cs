using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI.AiSummarize;
using Telnyx.net.Services.AI;
using Xunit;

namespace TelnyxTests.Services.AI
{
    public class AiSummaryServiceTest : BaseTelnyxTest
    {
        private readonly AiSummaryService service;
        private readonly UpsertAiSummary createOptions;

        public AiSummaryServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AiSummaryService();

            this.createOptions = new UpsertAiSummary()
            {
                BucketName = "string",
                Filename = "string"
            };

        }


        [Fact]
        public void Create()
        {
            var result = this.service.CreateAiSummary(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiSummary), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAiSummaryAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiSummary), result.GetType());
        }
    }
}
