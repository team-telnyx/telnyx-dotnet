using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobilePushCredentials;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Mobile push credential management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMobilePushCredentialService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMobilePushCredentialServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobilePushCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new mobile push credential for delivering push notifications to iOS or
/// Android apps, and returns the created credential.
/// </summary>
    Task<PushCredentialResponse> Create(
        MobilePushCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves mobile push credential based on the given `push_credential_id`
/// </summary>
    Task<PushCredentialResponse> Retrieve(
        MobilePushCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobilePushCredentialRetrieveParams, CancellationToken)"/>
    Task<PushCredentialResponse> Retrieve(
        string pushCredentialID,
        MobilePushCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the mobile push credentials on your account, with
/// support for filtering.
/// </summary>
    Task<MobilePushCredentialListPage> List(
        MobilePushCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a mobile push credential based on the given `push_credential_id`
/// </summary>
    Task Delete(
        MobilePushCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MobilePushCredentialDeleteParams, CancellationToken)"/>
    Task Delete(
        string pushCredentialID,
        MobilePushCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMobilePushCredentialService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMobilePushCredentialServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobilePushCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /mobile_push_credentials</c>, but is otherwise the
/// same as <see cref="IMobilePushCredentialService.Create(MobilePushCredentialCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PushCredentialResponse>> Create(
        MobilePushCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /mobile_push_credentials/{push_credential_id}</c>, but is otherwise the
/// same as <see cref="IMobilePushCredentialService.Retrieve(MobilePushCredentialRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PushCredentialResponse>> Retrieve(
        MobilePushCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobilePushCredentialRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PushCredentialResponse>> Retrieve(
        string pushCredentialID,
        MobilePushCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /mobile_push_credentials</c>, but is otherwise the
/// same as <see cref="IMobilePushCredentialService.List(MobilePushCredentialListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobilePushCredentialListPage>> List(
        MobilePushCredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /mobile_push_credentials/{push_credential_id}</c>, but is otherwise the
/// same as <see cref="IMobilePushCredentialService.Delete(MobilePushCredentialDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        MobilePushCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MobilePushCredentialDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string pushCredentialID,
        MobilePushCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}