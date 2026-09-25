using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Tools;

namespace Telnyx.Sdk.Services.AI;

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
/// Create a new custom AI tool that can be attached to AI assistants.
/// </summary>
    Task<SharedToolResponse> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a specific AI tool.
/// </summary>
    Task<SharedToolResponse> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ToolRetrieveParams, CancellationToken)"/>
    Task<SharedToolResponse> Retrieve(
        string toolID,
        ToolRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the configuration of an existing AI tool.
/// </summary>
    Task<SharedToolResponse> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ToolUpdateParams, CancellationToken)"/>
    Task<SharedToolResponse> Update(
        string toolID,
        ToolUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of the custom AI tools configured on your account.
/// </summary>
    Task<ToolListPage> List(
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified custom AI tool from your account.
/// </summary>
    Task<JsonElement> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ToolDeleteParams, CancellationToken)"/>
    Task<JsonElement> Delete(
        string toolID,
        ToolDeleteParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /ai/tools</c>, but is otherwise the
/// same as <see cref="IToolService.Create(ToolCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SharedToolResponse>> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.Retrieve(ToolRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SharedToolResponse>> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ToolRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SharedToolResponse>> Retrieve(
        string toolID,
        ToolRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.Update(ToolUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SharedToolResponse>> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ToolUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SharedToolResponse>> Update(
        string toolID,
        ToolUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/tools</c>, but is otherwise the
/// same as <see cref="IToolService.List(ToolListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ToolListPage>> List(
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.Delete(ToolDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ToolDeleteParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Delete(
        string toolID,
        ToolDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}