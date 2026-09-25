using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.Runs.Events;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns a paginated list of events logged for the specified run, filterable by
/// event type, plan step, and agent, so you can reconstruct exactly what happened
/// during execution.
/// </summary>
    Task<EventListPage> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(EventListParams, CancellationToken)"/>
    Task<EventListPage> List(
        string runID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single event logged for the specified run, including
/// its type and payload.
/// </summary>
    Task<EventResponse> GetEventDetails(
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetEventDetails(EventGetEventDetailsParams, CancellationToken)"/>
    Task<EventResponse> GetEventDetails(
        string eventID,
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Logs a new event against the specified run and returns the created event. Events
/// form the run's audit trail and can reference a plan step or agent.
/// </summary>
    Task<EventResponse> Log(
        EventLogParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Log(EventLogParams, CancellationToken)"/>
    Task<EventResponse> Log(
        string runID,
        EventLogParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}/events</c>, but is otherwise the
/// same as <see cref="IEventService.List(EventListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EventListPage>> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(EventListParams, CancellationToken)"/>
    Task<HttpResponse<EventListPage>> List(
        string runID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}/events/{event_id}</c>, but is otherwise the
/// same as <see cref="IEventService.GetEventDetails(EventGetEventDetailsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EventResponse>> GetEventDetails(
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetEventDetails(EventGetEventDetailsParams, CancellationToken)"/>
    Task<HttpResponse<EventResponse>> GetEventDetails(
        string eventID,
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/events</c>, but is otherwise the
/// same as <see cref="IEventService.Log(EventLogParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EventResponse>> Log(
        EventLogParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Log(EventLogParams, CancellationToken)"/>
    Task<HttpResponse<EventResponse>> Log(
        string runID,
        EventLogParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}