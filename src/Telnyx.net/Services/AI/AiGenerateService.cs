using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI.AiGenerates;

namespace Telnyx.net.Services.AI
{
    public class AiGenerateService : Service<AiGenerate>
    {
        public override string BasePath => "/ai/generate";

        public async Task<AiGenerate> CreateAiGenerateAsync(UpsertAiGenerate options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public AiGenerate CreateAiGenerate(UpsertAiGenerate options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
