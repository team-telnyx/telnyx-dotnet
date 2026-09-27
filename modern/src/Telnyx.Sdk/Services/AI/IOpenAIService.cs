using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI;
using Telnyx.Sdk.Models.AI.OpenAI;
using OpenAI = Telnyx.Sdk.Services.AI.OpenAI;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOpenAIService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOpenAIServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOpenAIService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    OpenAI::IEmbeddingService Embeddings { get; }

    OpenAI::IChatService Chat { get; }

    /// <summary>
/// Create a response using Telnyx's OpenAI-compatible Responses API. This endpoint
/// is compatible with the [OpenAI Responses
/// API](https://developers.openai.com/api/reference/responses/overview) and may be
/// used with the OpenAI JS or Python SDK by setting the base URL to
/// `https://api.telnyx.com/v2/ai/openai`.
/// 
/// <para>The `conversation` parameter refers to a Telnyx Conversation rather than
/// an OpenAI-hosted conversation object. To persist a thread across turns, first
/// [create a
/// conversation](https://developers.telnyx.com/api-reference/conversations/create-a-conversation)
/// with `POST /ai/conversations`, then pass that conversation's `id` in the
/// Responses request as `conversation`. The endpoint appends the new input,
/// assistant output, reasoning, and tool-call messages to that conversation. Reuse
/// the same `conversation` id on subsequent Responses requests, including
/// tool-result followups, so the model receives the prior context.</para>
/// 
/// <para>If `conversation` is omitted, the request is processed without persisting
/// messages to a Telnyx conversation. Use the Conversations API to manage history:
/// [list
/// conversations](https://developers.telnyx.com/api-reference/conversations/list-conversations)
/// (optionally filtered by metadata), [fetch
/// messages](https://developers.telnyx.com/api-reference/conversations/get-conversation-messages)
/// for a conversation, and optionally [add
/// messages](https://developers.telnyx.com/api-reference/conversations/create-message)
/// outside the Responses flow.</para>
/// 
/// <para>You can attach arbitrary metadata when creating a conversation (for
/// example to tag the conversation's source, channel, or user) and later filter by
/// it when listing conversations.</para>
/// </summary>
    Task<Dictionary<string, JsonElement>> CreateResponse(
        OpenAICreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists every model currently available to your account on Telnyx Inference,
/// including SOTA open-source LLMs hosted on Telnyx GPUs (for example
/// `moonshotai/Kimi-K2.6`, `zai-org/GLM-5.1-FP8`, and `MiniMaxAI/MiniMax-M2.7`),
/// embedding models, and any fine-tuned models you have created.
/// 
/// <para>Each entry is a `ModelMetadata` object describing the model id, owner,
/// task, context length, supported languages, billing tier, pricing per 1M tokens,
/// deployment regions, and whether the model supports vision or fine-tuning. Use
/// this endpoint to discover model ids you can pass to `POST
/// /v2/ai/openai/chat/completions`.</para>
/// 
/// <para>Model ids follow the `{organization}/{model_name}` convention from Hugging
/// Face (for example `moonshotai/Kimi-K2.6`). This endpoint is OpenAI-compatible:
/// clients pointed at `https://api.telnyx.com/v2/ai/openai` can call
/// `client.models.list()` to retrieve the same payload.</para>
/// </summary>
    Task<ModelsResponse> ListModels(
        OpenAIListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOpenAIService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOpenAIServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOpenAIServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    OpenAI::IEmbeddingServiceWithRawResponse Embeddings { get; }

    OpenAI::IChatServiceWithRawResponse Chat { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/openai/responses</c>, but is otherwise the
/// same as <see cref="IOpenAIService.CreateResponse(OpenAICreateResponseParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> CreateResponse(
        OpenAICreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/openai/models</c>, but is otherwise the
/// same as <see cref="IOpenAIService.ListModels(OpenAIListModelsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ModelsResponse>> ListModels(
        OpenAIListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}