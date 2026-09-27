using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UacConnections;
using UacConnections = Telnyx.Sdk.Services.UacConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// UAC connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUacConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUacConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUacConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    UacConnections::IActionService Actions { get; }

    /// <summary>
/// Creates a UAC connection. A UAC (User Agent Client) Connection registers Telnyx
/// to your PBX — the opposite of a standard SIP trunk, where the PBX registers to
/// Telnyx. Use UAC when your PBX doesn’t support outbound SIP registration or you
/// need Telnyx to maintain the registration.
/// </summary>
    Task<UacConnectionCreateResponse> Create(
        UacConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing UAC connection.
/// </summary>
    Task<UacConnectionRetrieveResponse> Retrieve(
        UacConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UacConnectionRetrieveParams, CancellationToken)"/>
    Task<UacConnectionRetrieveResponse> Retrieve(
        string id,
        UacConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing UAC connection.
/// </summary>
    Task<UacConnectionUpdateResponse> Update(
        UacConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(UacConnectionUpdateParams, CancellationToken)"/>
    Task<UacConnectionUpdateResponse> Update(
        string id,
        UacConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your UAC connections. A UAC (User Agent Client) Connection
/// registers Telnyx to your PBX — the opposite of a standard SIP trunk, where the
/// PBX registers to Telnyx. Use UAC when your PBX doesn’t support outbound SIP
/// registration or you need Telnyx to maintain the registration.
/// </summary>
    Task<UacConnectionListPage> List(
        UacConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified UAC connection from your account.
/// </summary>
    Task<UacConnectionDeleteResponse> Delete(
        UacConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(UacConnectionDeleteParams, CancellationToken)"/>
    Task<UacConnectionDeleteResponse> Delete(
        string id,
        UacConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUacConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUacConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUacConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    UacConnections::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /uac_connections</c>, but is otherwise the
/// same as <see cref="IUacConnectionService.Create(UacConnectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UacConnectionCreateResponse>> Create(
        UacConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /uac_connections/{id}</c>, but is otherwise the
/// same as <see cref="IUacConnectionService.Retrieve(UacConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UacConnectionRetrieveResponse>> Retrieve(
        UacConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UacConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UacConnectionRetrieveResponse>> Retrieve(
        string id,
        UacConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /uac_connections/{id}</c>, but is otherwise the
/// same as <see cref="IUacConnectionService.Update(UacConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UacConnectionUpdateResponse>> Update(
        UacConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(UacConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UacConnectionUpdateResponse>> Update(
        string id,
        UacConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /uac_connections</c>, but is otherwise the
/// same as <see cref="IUacConnectionService.List(UacConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UacConnectionListPage>> List(
        UacConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /uac_connections/{id}</c>, but is otherwise the
/// same as <see cref="IUacConnectionService.Delete(UacConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UacConnectionDeleteResponse>> Delete(
        UacConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(UacConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<UacConnectionDeleteResponse>> Delete(
        string id,
        UacConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}