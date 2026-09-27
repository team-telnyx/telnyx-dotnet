using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.OpenAI.Chat;

namespace Telnyx.Sdk.Services.AI.OpenAI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChatServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Chat with a language model. This endpoint is consistent with the [OpenAI Chat
/// Completions API](https://platform.openai.com/docs/api-reference/chat) and may be
/// used with the OpenAI JS or Python SDK by setting the base URL to
/// `https://api.telnyx.com/v2/ai/openai`.
/// </summary>
    Task<Dictionary<string, JsonElement>> CreateCompletion(
        ChatCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IChatService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChatServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/openai/chat/completions</c>, but is otherwise the
/// same as <see cref="IChatService.CreateCompletion(ChatCreateCompletionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> CreateCompletion(
        ChatCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}