using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI;
using Telnyx.net.Entities.AI.AiEmbeddings;
using Telnyx.net.Services.AI;
using Xunit;

namespace TelnyxTests.Services.AI
{
    public class AiEmbeddingServiceTest : BaseTelnyxTest
    {
        private readonly AiEmbeddingService service;
        private readonly UpsertAiEmbedding createOptions;

        public AiEmbeddingServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AiEmbeddingService();

            this.createOptions = new UpsertAiEmbedding()
            {
                BucketName = "string",
                DocumentChunkSize = 1024,
                DocumentChunkOverlapSize = 512,
                EmbeddingModel = new EmbeddingModel (),
                DocumentLoader = new DocumentLoader()
            };

        }


        [Fact]
        public void Create()
        {
            var result = this.service.CreateAiEmbedding(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiEmbedding), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await this.service.CreateAiEmbeddingAsync(this.createOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AiEmbedding), result.GetType());
        }
    }
}
