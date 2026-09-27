using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.OpenAI.Embeddings;

namespace Telnyx.Sdk.Services.AI.OpenAI;

/// <summary>
/// OpenAI-compatible embeddings endpoints for generating vector representations of text
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmbeddingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmbeddingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates an embedding vector representing the input text. This endpoint is
/// compatible with the [OpenAI Embeddings
/// API](https://platform.openai.com/docs/api-reference/embeddings) and may be used
/// with the OpenAI JS or Python SDK by setting the base URL to
/// `https://api.telnyx.com/v2/ai/openai`.
/// </summary>
    Task<EmbeddingCreateEmbeddingsResponse> CreateEmbeddings(
        EmbeddingCreateEmbeddingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of available embedding models. This endpoint is compatible with
/// the OpenAI Models API format.
/// </summary>
    Task<EmbeddingListEmbeddingModelsResponse> ListEmbeddingModels(
        EmbeddingListEmbeddingModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmbeddingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmbeddingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/openai/embeddings</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.CreateEmbeddings(EmbeddingCreateEmbeddingsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingCreateEmbeddingsResponse>> CreateEmbeddings(
        EmbeddingCreateEmbeddingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/openai/embeddings/models</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.ListEmbeddingModels(EmbeddingListEmbeddingModelsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingListEmbeddingModelsResponse>> ListEmbeddingModels(
        EmbeddingListEmbeddingModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}