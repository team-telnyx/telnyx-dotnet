using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OAuthGrants;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthGrantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthGrantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthGrantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the details of a single OAuth grant on your account by its ID.
/// </summary>
    Task<OAuthGrantRetrieveResponse> Retrieve(
        OAuthGrantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthGrantRetrieveParams, CancellationToken)"/>
    Task<OAuthGrantRetrieveResponse> Retrieve(
        string id,
        OAuthGrantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of OAuth grants for the authenticated user
/// </summary>
    Task<OAuthGrantListPage> List(
        OAuthGrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Revokes the specified OAuth grant, withdrawing the access previously granted to
/// the client.
/// </summary>
    Task<OAuthGrantDeleteResponse> Delete(
        OAuthGrantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OAuthGrantDeleteParams, CancellationToken)"/>
    Task<OAuthGrantDeleteResponse> Delete(
        string id,
        OAuthGrantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOAuthGrantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthGrantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthGrantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth_grants/{id}</c>, but is otherwise the
/// same as <see cref="IOAuthGrantService.Retrieve(OAuthGrantRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthGrantRetrieveResponse>> Retrieve(
        OAuthGrantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthGrantRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OAuthGrantRetrieveResponse>> Retrieve(
        string id,
        OAuthGrantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth_grants</c>, but is otherwise the
/// same as <see cref="IOAuthGrantService.List(OAuthGrantListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthGrantListPage>> List(
        OAuthGrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /oauth_grants/{id}</c>, but is otherwise the
/// same as <see cref="IOAuthGrantService.Delete(OAuthGrantDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthGrantDeleteResponse>> Delete(
        OAuthGrantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OAuthGrantDeleteParams, CancellationToken)"/>
    Task<HttpResponse<OAuthGrantDeleteResponse>> Delete(
        string id,
        OAuthGrantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}