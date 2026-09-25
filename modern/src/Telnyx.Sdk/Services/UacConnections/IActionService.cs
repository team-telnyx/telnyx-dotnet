using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UacConnections.Actions;

namespace Telnyx.Sdk.Services.UacConnections;

/// <summary>
/// UAC connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
/// Returns the live SIP registration status for a UAC connection. Reports whether
/// the endpoint is currently registered (`status`) and the timestamp of the last
/// SIP registration event (`last_registration`).
/// </summary>
    Task<ActionCheckRegistrationStatusResponse> CheckRegistrationStatus(
        ActionCheckRegistrationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CheckRegistrationStatus(ActionCheckRegistrationStatusParams, CancellationToken)"/>
    Task<ActionCheckRegistrationStatusResponse> CheckRegistrationStatus(
        string id,
        ActionCheckRegistrationStatusParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /uac_connections/{id}/actions/check_registration_status</c>, but is otherwise the
/// same as <see cref="IActionService.CheckRegistrationStatus(ActionCheckRegistrationStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionCheckRegistrationStatusResponse>> CheckRegistrationStatus(
        ActionCheckRegistrationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CheckRegistrationStatus(ActionCheckRegistrationStatusParams, CancellationToken)"/>
    Task<HttpResponse<ActionCheckRegistrationStatusResponse>> CheckRegistrationStatus(
        string id,
        ActionCheckRegistrationStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}