using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TelephonyCredentials;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITelephonyCredentialService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITelephonyCredentialServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelephonyCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new on-demand telephony credential for the specified connection. The
/// credential can then be used to generate access tokens for SIP or WebRTC clients.
/// </summary>
    Task<TelephonyCredentialCreateResponse> Create(
        TelephonyCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the details of an existing On-demand Credential.
/// </summary>
    Task<TelephonyCredentialRetrieveResponse> Retrieve(
        TelephonyCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TelephonyCredentialRetrieveParams, CancellationToken)"/>
    Task<TelephonyCredentialRetrieveResponse> Retrieve(
        string id,
        TelephonyCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified telephony credential and returns the updated credential.
/// </summary>
    Task<TelephonyCredentialUpdateResponse> Update(
        TelephonyCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TelephonyCredentialUpdateParams, CancellationToken)"/>
    Task<TelephonyCredentialUpdateResponse> Update(
        string id,
        TelephonyCredentialUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the on-demand telephony credentials on your account,
/// with support for filtering.
/// </summary>
    Task<TelephonyCredentialListPage> List(
        TelephonyCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified telephony credential, revoking any access it
/// provided.
/// </summary>
    Task<TelephonyCredentialDeleteResponse> Delete(
        TelephonyCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TelephonyCredentialDeleteParams, CancellationToken)"/>
    Task<TelephonyCredentialDeleteResponse> Delete(
        string id,
        TelephonyCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Create an Access Token (JWT) for the credential.
/// </summary>
    Task<string> CreateToken(
        TelephonyCredentialCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateToken(TelephonyCredentialCreateTokenParams, CancellationToken)"/>
    Task<string> CreateToken(
        string id,
        TelephonyCredentialCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITelephonyCredentialService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITelephonyCredentialServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelephonyCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /telephony_credentials</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.Create(TelephonyCredentialCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelephonyCredentialCreateResponse>> Create(
        TelephonyCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /telephony_credentials/{id}</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.Retrieve(TelephonyCredentialRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelephonyCredentialRetrieveResponse>> Retrieve(
        TelephonyCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TelephonyCredentialRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TelephonyCredentialRetrieveResponse>> Retrieve(
        string id,
        TelephonyCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /telephony_credentials/{id}</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.Update(TelephonyCredentialUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelephonyCredentialUpdateResponse>> Update(
        TelephonyCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TelephonyCredentialUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TelephonyCredentialUpdateResponse>> Update(
        string id,
        TelephonyCredentialUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /telephony_credentials</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.List(TelephonyCredentialListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelephonyCredentialListPage>> List(
        TelephonyCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /telephony_credentials/{id}</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.Delete(TelephonyCredentialDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelephonyCredentialDeleteResponse>> Delete(
        TelephonyCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TelephonyCredentialDeleteParams, CancellationToken)"/>
    Task<HttpResponse<TelephonyCredentialDeleteResponse>> Delete(
        string id,
        TelephonyCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /telephony_credentials/{id}/token</c>, but is otherwise the
/// same as <see cref="ITelephonyCredentialService.CreateToken(TelephonyCredentialCreateTokenParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> CreateToken(
        TelephonyCredentialCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateToken(TelephonyCredentialCreateTokenParams, CancellationToken)"/>
    Task<HttpResponse<string>> CreateToken(
        string id,
        TelephonyCredentialCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}