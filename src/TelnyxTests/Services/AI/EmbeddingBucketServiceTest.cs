using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.EmbeddingBuckets;
using Telnyx.net.Services.PhoneNumbers.EmbeddingBuckets;
using Xunit;

namespace TelnyxTests.Services.AI
{
    public class EmbeddingBucketServiceTest : BaseTelnyxTest
    {
        private readonly EmbeddingBucketService service;
        private readonly EmbeddingBucketOption listOptions;
        private readonly BaseOptions baseOptions;
        private readonly RequestOptions requestOptions;

        public EmbeddingBucketServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new EmbeddingBucketService();

            this.listOptions = new EmbeddingBucketOption()
            {
                BucketName = ""
            };
            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }
        [Fact]
        public void List()
        {
            var result = this.service.ListEmbeddingBucket(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<EmbeddingBucket>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListEmbeddingBucketAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<EmbeddingBucket>), result.GetType());
        }

    }
}
