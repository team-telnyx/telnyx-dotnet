using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI;
using Telnyx.Sdk.Services.AI;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAIService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAIServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAIService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IAssistantService Assistants { get; }

    IAudioService Audio { get; }

    IChatService Chat { get; }

    IClusterService Clusters { get; }

    ICollectionService Collections { get; }

    IConversationService Conversations { get; }

    IEmbeddingService Embeddings { get; }

    IFineTuningService FineTuning { get; }

    IIntegrationService Integrations { get; }

    IMcpServerService McpServers { get; }

    IMissionService Missions { get; }

    IOpenAIService OpenAI { get; }

    IToolService Tools { get; }

    IAnthropicService Anthropic { get; }

    IKnowledgeService Knowledge { get; }

    ITypesafeService Typesafe { get; }

    IMemoryService Memory { get; }

    /// <summary>
/// Performs semantic vector search across conversation history records.
/// 
/// <para>**How it works:** 1. The query text is embedded into a 1024-dimensional
/// vector using the multilingual-e5-large model. 2. The vector is compared against
/// indexed record chunks using semantic similarity search. 3. When no region is
/// specified, all regions are queried in parallel (fan-out) and results are merged
/// by score. 4. Results are ranked by similarity score (descending) and paginated
/// via `page[number]` / `page[size]`.</para>
/// 
/// <para>**Authentication:** Requires a Telnyx API key via `Authorization: Bearer
/// &lt;key&gt;`. Results are automatically scoped to the caller's organization —
/// `organization_id` is injected from the auth token and cannot be overridden.</para>
/// 
/// <para>**Chunking:** Records are split into chunks of up to 480 tokens with
/// 64-token overlap at ingestion time. Each search result represents a single
/// chunk, with `chunk_index` and `chunk_total` indicating its position within the
/// original record.</para>
/// 
/// <para>**Filtering:** Use `filter[field][operator]=value` query parameters to
/// narrow results before vector search.</para>
/// 
/// <para>Top-level filterable fields: `user_id`, `region`, `record_id`,
/// `record_created_at`, `ingested_at`, `retention`</para>
/// 
/// <para>Note: `retention` is filter-only — it can be used to narrow results but is
/// not returned in the response body.</para>
/// 
/// <para>Metadata fields: any field not in the list above is resolved to
/// `data.metadata.&lt;field&gt;` (e.g., `filter[language]=en` →
/// `data.metadata.language`).</para>
/// 
/// <para>Supported filter operators: - `eq` — exact match (default when no operator
/// specified) - `in` — match any of comma-separated values - `gte`, `gt`, `lte`,
/// `lt` — range comparisons (useful for date filtering) - `contains` — wildcard
/// substring match</para>
/// 
/// <para>**Examples:** - `GET
/// /v2/ai/conversation_histories?q=billing+issue&amp;page[size]=10` - `GET
/// /v2/ai/conversation_histories?q=setup+guide&amp;region=USA&amp;min_score=0.5` -
/// `GET
/// /v2/ai/conversation_histories?q=refund&amp;filter[record_created_at][gte]=2026-01-01T00:00:00Z`
/// - `GET /v2/ai/conversation_histories?q=outage&amp;filter[region][in]=USA,DEU` -
/// `GET /v2/ai/conversation_histories?q=hold+time&amp;filter[language]=en`</para>
/// </summary>
    Task<AIRetrieveConversationHistoriesPage> RetrieveConversationHistories(
        AIRetrieveConversationHistoriesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Generate a summary of a file's contents.
/// 
/// <para> Supports the following text formats:  - PDF, HTML, txt, json, csv</para>
/// 
/// <para> Supports the following media formats (billed for both the transcription and
/// summary):  - flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm - Up to 100 MB</para>
/// </summary>
    Task<AISummarizeResponse> Summarize(
        AISummarizeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAIService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAIServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAIServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IAssistantServiceWithRawResponse Assistants { get; }

    IAudioServiceWithRawResponse Audio { get; }

    IChatServiceWithRawResponse Chat { get; }

    IClusterServiceWithRawResponse Clusters { get; }

    ICollectionServiceWithRawResponse Collections { get; }

    IConversationServiceWithRawResponse Conversations { get; }

    IEmbeddingServiceWithRawResponse Embeddings { get; }

    IFineTuningServiceWithRawResponse FineTuning { get; }

    IIntegrationServiceWithRawResponse Integrations { get; }

    IMcpServerServiceWithRawResponse McpServers { get; }

    IMissionServiceWithRawResponse Missions { get; }

    IOpenAIServiceWithRawResponse OpenAI { get; }

    IToolServiceWithRawResponse Tools { get; }

    IAnthropicServiceWithRawResponse Anthropic { get; }

    IKnowledgeServiceWithRawResponse Knowledge { get; }

    ITypesafeServiceWithRawResponse Typesafe { get; }

    IMemoryServiceWithRawResponse Memory { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversation_histories</c>, but is otherwise the
/// same as <see cref="IAIService.RetrieveConversationHistories(AIRetrieveConversationHistoriesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AIRetrieveConversationHistoriesPage>> RetrieveConversationHistories(
        AIRetrieveConversationHistoriesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/summarize</c>, but is otherwise the
/// same as <see cref="IAIService.Summarize(AISummarizeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AISummarizeResponse>> Summarize(
        AISummarizeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}