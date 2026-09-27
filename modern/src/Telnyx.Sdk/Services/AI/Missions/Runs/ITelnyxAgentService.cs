using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITelnyxAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITelnyxAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelnyxAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the Telnyx agents currently linked to the specified run. Linked agents
/// participate in executing the run's plan.
/// </summary>
    Task<TelnyxAgentListResponse> List(
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(TelnyxAgentListParams, CancellationToken)"/>
    Task<TelnyxAgentListResponse> List(
        string runID,
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Link a Telnyx AI agent (voice/messaging) to a run
/// </summary>
    Task<TelnyxAgentLinkResponse> Link(
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Link(TelnyxAgentLinkParams, CancellationToken)"/>
    Task<TelnyxAgentLinkResponse> Link(
        string runID,
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Unlinks the specified Telnyx agent from the run so it no longer participates in
/// execution. The run itself and its history are unaffected.
/// </summary>
    Task Unlink(
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unlink(TelnyxAgentUnlinkParams, CancellationToken)"/>
    Task Unlink(
        string telnyxAgentID,
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITelnyxAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITelnyxAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelnyxAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}/telnyx-agents</c>, but is otherwise the
/// same as <see cref="ITelnyxAgentService.List(TelnyxAgentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxAgentListResponse>> List(
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(TelnyxAgentListParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxAgentListResponse>> List(
        string runID,
        TelnyxAgentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/telnyx-agents</c>, but is otherwise the
/// same as <see cref="ITelnyxAgentService.Link(TelnyxAgentLinkParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxAgentLinkResponse>> Link(
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Link(TelnyxAgentLinkParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxAgentLinkResponse>> Link(
        string runID,
        TelnyxAgentLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/missions/{mission_id}/runs/{run_id}/telnyx-agents/{telnyx_agent_id}</c>, but is otherwise the
/// same as <see cref="ITelnyxAgentService.Unlink(TelnyxAgentUnlinkParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Unlink(
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unlink(TelnyxAgentUnlinkParams, CancellationToken)"/>
    Task<HttpResponse> Unlink(
        string telnyxAgentID,
        TelnyxAgentUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}