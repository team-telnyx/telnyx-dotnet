using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CustomStorageCredentials;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Call Recordings operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICustomStorageCredentialService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomStorageCredentialServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomStorageCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a custom storage credentials configuration.
/// </summary>
    Task<CredentialsResponse> Create(
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CustomStorageCredentialCreateParams, CancellationToken)"/>
    Task<CredentialsResponse> Create(
        string connectionID,
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the information about custom storage credentials.
/// </summary>
    Task<CredentialsResponse> Retrieve(
        CustomStorageCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CustomStorageCredentialRetrieveParams, CancellationToken)"/>
    Task<CredentialsResponse> Retrieve(
        string connectionID,
        CustomStorageCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates a stored custom credentials configuration.
/// </summary>
    Task<CredentialsResponse> Update(
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CustomStorageCredentialUpdateParams, CancellationToken)"/>
    Task<CredentialsResponse> Update(
        string connectionID,
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a stored custom credentials configuration.
/// </summary>
    Task Delete(
        CustomStorageCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CustomStorageCredentialDeleteParams, CancellationToken)"/>
    Task Delete(
        string connectionID,
        CustomStorageCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICustomStorageCredentialService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomStorageCredentialServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomStorageCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /custom_storage_credentials/{connection_id}</c>, but is otherwise the
/// same as <see cref="ICustomStorageCredentialService.Create(CustomStorageCredentialCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialsResponse>> Create(
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CustomStorageCredentialCreateParams, CancellationToken)"/>
    Task<HttpResponse<CredentialsResponse>> Create(
        string connectionID,
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /custom_storage_credentials/{connection_id}</c>, but is otherwise the
/// same as <see cref="ICustomStorageCredentialService.Retrieve(CustomStorageCredentialRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialsResponse>> Retrieve(
        CustomStorageCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CustomStorageCredentialRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CredentialsResponse>> Retrieve(
        string connectionID,
        CustomStorageCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /custom_storage_credentials/{connection_id}</c>, but is otherwise the
/// same as <see cref="ICustomStorageCredentialService.Update(CustomStorageCredentialUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialsResponse>> Update(
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CustomStorageCredentialUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CredentialsResponse>> Update(
        string connectionID,
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /custom_storage_credentials/{connection_id}</c>, but is otherwise the
/// same as <see cref="ICustomStorageCredentialService.Delete(CustomStorageCredentialDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        CustomStorageCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CustomStorageCredentialDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string connectionID,
        CustomStorageCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}