using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

namespace Telnyx.Sdk.Services.FqdnConnections;

/// <summary>
/// FQDN connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFqdnAuthenticationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFqdnAuthenticationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnAuthenticationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieves the details of an existing FQDN authentication strategy for a specific
/// FQDN connection.
/// </summary>
    Task<FqdnAuthenticationListResponse> List(
        FqdnAuthenticationListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(FqdnAuthenticationListParams, CancellationToken)"/>
    Task<FqdnAuthenticationListResponse> List(
        string fqdnConnectionID,
        FqdnAuthenticationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the FQDN authentication strategy for a specific FQDN connection.
/// </summary>
    Task<FqdnAuthenticationPatchAllResponse> PatchAll(
        FqdnAuthenticationPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(FqdnAuthenticationPatchAllParams, CancellationToken)"/>
    Task<FqdnAuthenticationPatchAllResponse> PatchAll(
        string fqdnConnectionID,
        FqdnAuthenticationPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFqdnAuthenticationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFqdnAuthenticationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnAuthenticationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fqdn_connections/{fqdn_connection_id}/fqdn_authentication</c>, but is otherwise the
/// same as <see cref="IFqdnAuthenticationService.List(FqdnAuthenticationListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnAuthenticationListResponse>> List(
        FqdnAuthenticationListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(FqdnAuthenticationListParams, CancellationToken)"/>
    Task<HttpResponse<FqdnAuthenticationListResponse>> List(
        string fqdnConnectionID,
        FqdnAuthenticationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /fqdn_connections/{fqdn_connection_id}/fqdn_authentication</c>, but is otherwise the
/// same as <see cref="IFqdnAuthenticationService.PatchAll(FqdnAuthenticationPatchAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnAuthenticationPatchAllResponse>> PatchAll(
        FqdnAuthenticationPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(FqdnAuthenticationPatchAllParams, CancellationToken)"/>
    Task<HttpResponse<FqdnAuthenticationPatchAllResponse>> PatchAll(
        string fqdnConnectionID,
        FqdnAuthenticationPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}