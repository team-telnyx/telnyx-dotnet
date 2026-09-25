using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tools;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IToolService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IToolServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Attach an existing tool to an AI assistant.
/// </summary>
    Task<JsonElement> Add(
        ToolAddParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(ToolAddParams, CancellationToken)"/>
    Task<JsonElement> Add(
        string toolID,
        ToolAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Detaches the specified tool from the AI assistant so the assistant can no longer
/// invoke it.
/// </summary>
    Task<JsonElement> Remove(
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(ToolRemoveParams, CancellationToken)"/>
    Task<JsonElement> Remove(
        string toolID,
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Executes a test invocation of the specified webhook tool for the assistant and
/// returns the outcome, so you can verify the webhook's behavior before relying on
/// it in conversations.
/// </summary>
    Task<ToolTestResponse> Test(
        ToolTestParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Test(ToolTestParams, CancellationToken)"/>
    Task<ToolTestResponse> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IToolService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IToolServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/assistants/{assistant_id}/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.Add(ToolAddParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> Add(
        ToolAddParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(ToolAddParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Add(
        string toolID,
        ToolAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.Remove(ToolRemoveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> Remove(
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(ToolRemoveParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Remove(
        string toolID,
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/tools/{tool_id}/test</c>, but is otherwise the
/// same as <see cref="IToolService.Test(ToolTestParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ToolTestResponse>> Test(
        ToolTestParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Test(ToolTestParams, CancellationToken)"/>
    Task<HttpResponse<ToolTestResponse>> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}