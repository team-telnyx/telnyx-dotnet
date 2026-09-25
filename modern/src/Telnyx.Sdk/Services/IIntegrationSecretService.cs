using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.IntegrationSecrets;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Store and retrieve integration secrets
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIntegrationSecretService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntegrationSecretServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationSecretService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new secret with an associated identifier that can be used to securely
/// integrate with other services.
/// </summary>
    Task<IntegrationSecretCreateResponse> Create(
        IntegrationSecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of all integration secrets configured by the user.
/// </summary>
    Task<IntegrationSecretListPage> List(
        IntegrationSecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete an integration secret given its ID.
/// </summary>
    Task Delete(
        IntegrationSecretDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IntegrationSecretDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        IntegrationSecretDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IIntegrationSecretService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntegrationSecretServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationSecretServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /integration_secrets</c>, but is otherwise the
/// same as <see cref="IIntegrationSecretService.Create(IntegrationSecretCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IntegrationSecretCreateResponse>> Create(
        IntegrationSecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /integration_secrets</c>, but is otherwise the
/// same as <see cref="IIntegrationSecretService.List(IntegrationSecretListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IntegrationSecretListPage>> List(
        IntegrationSecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /integration_secrets/{id}</c>, but is otherwise the
/// same as <see cref="IIntegrationSecretService.Delete(IntegrationSecretDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        IntegrationSecretDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IntegrationSecretDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        IntegrationSecretDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}