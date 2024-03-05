using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.AI.AiSummarize;

namespace Telnyx.net.Services.AI
{
    public class AiSummaryService : Service<AiSummary>
    {
        public override string BasePath => "/ai/summarize";

        public async Task<AiSummary> CreateAiSummaryAsync(UpsertAiSummary options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public AiSummary CreateAiSummary(UpsertAiSummary options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
