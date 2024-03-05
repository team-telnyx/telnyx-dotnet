using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI;
using Telnyx.net.Entities.AI.AiEmbeddings;

namespace Telnyx.net.Services.AI
{
    public class AiEmbeddingService : Service<AiEmbedding>
    {
        public override string BasePath => "/ai/embeddings";

        public async Task<AiEmbedding> CreateAiEmbeddingAsync(UpsertAiEmbedding options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public AiEmbedding CreateAiEmbedding(UpsertAiEmbedding options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
