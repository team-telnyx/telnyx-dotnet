using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OAuth;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve details about an OAuth consent token
/// </summary>
    Task<OAuthRetrieveResponse> Retrieve(
        OAuthRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthRetrieveParams, CancellationToken)"/>
    Task<OAuthRetrieveResponse> Retrieve(
        string consentToken,
        OAuthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates an OAuth authorization grant and returns the grant response for
/// completing the authorization flow.
/// </summary>
    Task<OAuthGrantsResponse> Grants(
        OAuthGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Introspect an OAuth access token to check its validity and metadata
/// </summary>
    Task<OAuthIntrospectResponse> Introspect(
        OAuthIntrospectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Register a new OAuth client dynamically (RFC 7591)
/// </summary>
    Task<OAuthRegisterResponse> Register(
        OAuthRegisterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// OAuth 2.0 authorization endpoint for the authorization code flow
/// </summary>
    Task<string> RetrieveAuthorize(
        OAuthRetrieveAuthorizeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the JSON Web Key Set for token verification
/// </summary>
    Task<OAuthRetrieveJwksResponse> RetrieveJwks(
        OAuthRetrieveJwksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Exchange authorization code, client credentials, or refresh token for access
/// token
/// </summary>
    Task<OAuthTokenResponse> Token(
        OAuthTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOAuthService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth/consent/{consent_token}</c>, but is otherwise the
/// same as <see cref="IOAuthService.Retrieve(OAuthRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthRetrieveResponse>> Retrieve(
        OAuthRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OAuthRetrieveResponse>> Retrieve(
        string consentToken,
        OAuthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /oauth/grants</c>, but is otherwise the
/// same as <see cref="IOAuthService.Grants(OAuthGrantsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthGrantsResponse>> Grants(
        OAuthGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /oauth/introspect</c>, but is otherwise the
/// same as <see cref="IOAuthService.Introspect(OAuthIntrospectParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthIntrospectResponse>> Introspect(
        OAuthIntrospectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /oauth/register</c>, but is otherwise the
/// same as <see cref="IOAuthService.Register(OAuthRegisterParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthRegisterResponse>> Register(
        OAuthRegisterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth/authorize</c>, but is otherwise the
/// same as <see cref="IOAuthService.RetrieveAuthorize(OAuthRetrieveAuthorizeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> RetrieveAuthorize(
        OAuthRetrieveAuthorizeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth/jwks</c>, but is otherwise the
/// same as <see cref="IOAuthService.RetrieveJwks(OAuthRetrieveJwksParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthRetrieveJwksResponse>> RetrieveJwks(
        OAuthRetrieveJwksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /oauth/token</c>, but is otherwise the
/// same as <see cref="IOAuthService.Token(OAuthTokenParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthTokenResponse>> Token(
        OAuthTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}