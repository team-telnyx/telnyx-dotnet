using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Anthropic.V1;

namespace Telnyx.Sdk.Services.AI.Anthropic;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Send a message to a language model using the Anthropic Messages API format. This
/// endpoint is compatible with the [Anthropic Messages
/// API](https://docs.anthropic.com/en/api/messages) and may be used with the
/// Anthropic JS or Python SDK by setting the base URL to
/// `https://api.telnyx.com/v2/ai/anthropic`.
/// 
/// <para>The endpoint translates Anthropic-format requests into Telnyx's inference
/// internals, then translates the response back to the Anthropic message shape.
/// Streaming responses use Anthropic SSE event types (`message_start`,
/// `content_block_start`, `content_block_delta`, `content_block_stop`,
/// `message_delta`, `message_stop`).</para>
/// </summary>
    Task<Dictionary<string, JsonElement>> Messages(
        V1MessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/anthropic/v1/messages</c>, but is otherwise the
/// same as <see cref="IV1Service.Messages(V1MessagesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> Messages(
        V1MessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}