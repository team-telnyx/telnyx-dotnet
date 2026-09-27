using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OAuthClients;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthClientService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthClientServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthClientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new OAuth client on your account for authenticating third-party
/// integrations, and returns the created client.
/// </summary>
    Task<OAuthClientCreateResponse> Create(
        OAuthClientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single OAuth client on your account by its ID.
/// </summary>
    Task<OAuthClientRetrieveResponse> Retrieve(
        OAuthClientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthClientRetrieveParams, CancellationToken)"/>
    Task<OAuthClientRetrieveResponse> Retrieve(
        string id,
        OAuthClientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified OAuth client's configuration and returns the updated
/// client.
/// </summary>
    Task<OAuthClientUpdateResponse> Update(
        OAuthClientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(OAuthClientUpdateParams, CancellationToken)"/>
    Task<OAuthClientUpdateResponse> Update(
        string id,
        OAuthClientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of OAuth clients for the authenticated user
/// </summary>
    Task<OAuthClientListPage> List(
        OAuthClientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified OAuth client from your account.
/// </summary>
    Task Delete(
        OAuthClientDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OAuthClientDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        OAuthClientDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOAuthClientService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthClientServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthClientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /oauth_clients</c>, but is otherwise the
/// same as <see cref="IOAuthClientService.Create(OAuthClientCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthClientCreateResponse>> Create(
        OAuthClientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth_clients/{id}</c>, but is otherwise the
/// same as <see cref="IOAuthClientService.Retrieve(OAuthClientRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthClientRetrieveResponse>> Retrieve(
        OAuthClientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OAuthClientRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OAuthClientRetrieveResponse>> Retrieve(
        string id,
        OAuthClientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /oauth_clients/{id}</c>, but is otherwise the
/// same as <see cref="IOAuthClientService.Update(OAuthClientUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthClientUpdateResponse>> Update(
        OAuthClientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(OAuthClientUpdateParams, CancellationToken)"/>
    Task<HttpResponse<OAuthClientUpdateResponse>> Update(
        string id,
        OAuthClientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /oauth_clients</c>, but is otherwise the
/// same as <see cref="IOAuthClientService.List(OAuthClientListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OAuthClientListPage>> List(
        OAuthClientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /oauth_clients/{id}</c>, but is otherwise the
/// same as <see cref="IOAuthClientService.Delete(OAuthClientDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        OAuthClientDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(OAuthClientDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        OAuthClientDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}