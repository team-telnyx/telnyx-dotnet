using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingProfiles.Actions;

namespace Telnyx.Sdk.Services.MessagingProfiles;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Regenerate the v1 secret for a messaging profile.
/// </summary>
    Task<ActionRegenerateSecretResponse> RegenerateSecret(
        ActionRegenerateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RegenerateSecret(ActionRegenerateSecretParams, CancellationToken)"/>
    Task<ActionRegenerateSecretResponse> RegenerateSecret(
        string id,
        ActionRegenerateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_profiles/{id}/actions/regenerate_secret</c>, but is otherwise the
/// same as <see cref="IActionService.RegenerateSecret(ActionRegenerateSecretParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRegenerateSecretResponse>> RegenerateSecret(
        ActionRegenerateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RegenerateSecret(ActionRegenerateSecretParams, CancellationToken)"/>
    Task<HttpResponse<ActionRegenerateSecretResponse>> RegenerateSecret(
        string id,
        ActionRegenerateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}