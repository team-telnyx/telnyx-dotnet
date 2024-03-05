using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI.AiGenerates;
using Telnyx.net.Services.AI;
using Xunit;

namespace TelnyxTests.Services.AI
{
    public class AiGenerateServiceTest : BaseTelnyxTest
    {
        private readonly AiGenerateService service;
        private readonly UpsertAiGenerate createOptions;

        public AiGenerateServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AiGenerateService();

            this.createOptions = new UpsertAiGenerate()
            {
                Text =  new string[] { "string" },
                SupportedModels = "meta-llama/Llama-2-13b-chat-hf",
                Bucket = new Bucket(),
                OpenaiApiKey = "string",
                MaxTokens = 128,
                Temperature = 0.9
            };

        }


        [Fact]
        public void Create()
        {
            var result = this.service.CreateAiGenerate(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiGenerate), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAiGenerateAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiGenerate), result.GetType());
        }
    }
}
