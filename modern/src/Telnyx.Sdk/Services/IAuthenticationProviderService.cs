using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAuthenticationProviderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuthenticationProviderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthenticationProviderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new authentication provider for single sign-on, configured from the
/// provided identity provider details, and returns the created resource.
/// </summary>
    Task<AuthenticationProviderCreateResponse> Create(
        AuthenticationProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing authentication provider.
/// </summary>
    Task<AuthenticationProviderRetrieveResponse> Retrieve(
        AuthenticationProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AuthenticationProviderRetrieveParams, CancellationToken)"/>
    Task<AuthenticationProviderRetrieveResponse> Retrieve(
        string id,
        AuthenticationProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing authentication provider.
/// </summary>
    Task<AuthenticationProviderUpdateResponse> Update(
        AuthenticationProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AuthenticationProviderUpdateParams, CancellationToken)"/>
    Task<AuthenticationProviderUpdateResponse> Update(
        string id,
        AuthenticationProviderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your SSO authentication providers.
/// </summary>
    Task<AuthenticationProviderListPage> List(
        AuthenticationProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an existing authentication provider.
/// </summary>
    Task<AuthenticationProviderDeleteResponse> Delete(
        AuthenticationProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AuthenticationProviderDeleteParams, CancellationToken)"/>
    Task<AuthenticationProviderDeleteResponse> Delete(
        string id,
        AuthenticationProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAuthenticationProviderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuthenticationProviderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthenticationProviderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /authentication_providers</c>, but is otherwise the
/// same as <see cref="IAuthenticationProviderService.Create(AuthenticationProviderCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuthenticationProviderCreateResponse>> Create(
        AuthenticationProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /authentication_providers/{id}</c>, but is otherwise the
/// same as <see cref="IAuthenticationProviderService.Retrieve(AuthenticationProviderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuthenticationProviderRetrieveResponse>> Retrieve(
        AuthenticationProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AuthenticationProviderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AuthenticationProviderRetrieveResponse>> Retrieve(
        string id,
        AuthenticationProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /authentication_providers/{id}</c>, but is otherwise the
/// same as <see cref="IAuthenticationProviderService.Update(AuthenticationProviderUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuthenticationProviderUpdateResponse>> Update(
        AuthenticationProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AuthenticationProviderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AuthenticationProviderUpdateResponse>> Update(
        string id,
        AuthenticationProviderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /authentication_providers</c>, but is otherwise the
/// same as <see cref="IAuthenticationProviderService.List(AuthenticationProviderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuthenticationProviderListPage>> List(
        AuthenticationProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /authentication_providers/{id}</c>, but is otherwise the
/// same as <see cref="IAuthenticationProviderService.Delete(AuthenticationProviderDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuthenticationProviderDeleteResponse>> Delete(
        AuthenticationProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AuthenticationProviderDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AuthenticationProviderDeleteResponse>> Delete(
        string id,
        AuthenticationProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}