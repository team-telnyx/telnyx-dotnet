using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Migrations.Actions;

namespace Telnyx.Sdk.Services.Storage.Migrations;

/// <summary>
/// Migrate data from an external provider into Telnyx Cloud Storage
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
/// Stops the specified in-progress storage migration and returns the updated
/// migration.
/// </summary>
    Task<ActionStopResponse> Stop(
        ActionStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Stop(ActionStopParams, CancellationToken)"/>
    Task<ActionStopResponse> Stop(
        string id,
        ActionStopParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /storage/migrations/{id}/actions/stop</c>, but is otherwise the
/// same as <see cref="IActionService.Stop(ActionStopParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopResponse>> Stop(
        ActionStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Stop(ActionStopParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopResponse>> Stop(
        string id,
        ActionStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}