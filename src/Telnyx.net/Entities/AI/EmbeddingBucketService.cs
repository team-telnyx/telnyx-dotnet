using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.EmbeddingBuckets;

namespace Telnyx.net.Services.PhoneNumbers.EmbeddingBuckets
{
    public class EmbeddingBucketService : Service<EmbeddingBucket>
    {
        public override string BasePath => "/ai/embeddings/buckets";

        public async Task<TelnyxList<EmbeddingBucket>> ListEmbeddingBucketAsync(EmbeddingBucketOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<EmbeddingBucket> ListEmbeddingBucket(EmbeddingBucketOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
