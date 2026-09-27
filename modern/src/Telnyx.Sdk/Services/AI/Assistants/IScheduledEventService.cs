using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IScheduledEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IScheduledEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScheduledEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a scheduled event for an assistant
/// </summary>
    Task<ScheduledEventResponse> Create(
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ScheduledEventCreateParams, CancellationToken)"/>
    Task<ScheduledEventResponse> Create(
        string assistantID,
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single scheduled event configured for the specified
/// assistant.
/// </summary>
    Task<ScheduledEventResponse> Retrieve(
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ScheduledEventRetrieveParams, CancellationToken)"/>
    Task<ScheduledEventResponse> Retrieve(
        string eventID,
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get scheduled events for an assistant with pagination and filtering
/// </summary>
    Task<ScheduledEventListPage> List(
        ScheduledEventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ScheduledEventListParams, CancellationToken)"/>
    Task<ScheduledEventListPage> List(
        string assistantID,
        ScheduledEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// If the event is pending, this will cancel the event. Otherwise, this will simply
/// remove the record of the event.
/// </summary>
    Task Delete(
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ScheduledEventDeleteParams, CancellationToken)"/>
    Task Delete(
        string eventID,
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IScheduledEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IScheduledEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScheduledEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/scheduled_events</c>, but is otherwise the
/// same as <see cref="IScheduledEventService.Create(ScheduledEventCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ScheduledEventResponse>> Create(
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ScheduledEventCreateParams, CancellationToken)"/>
    Task<HttpResponse<ScheduledEventResponse>> Create(
        string assistantID,
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/scheduled_events/{event_id}</c>, but is otherwise the
/// same as <see cref="IScheduledEventService.Retrieve(ScheduledEventRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ScheduledEventResponse>> Retrieve(
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ScheduledEventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ScheduledEventResponse>> Retrieve(
        string eventID,
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/scheduled_events</c>, but is otherwise the
/// same as <see cref="IScheduledEventService.List(ScheduledEventListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ScheduledEventListPage>> List(
        ScheduledEventListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ScheduledEventListParams, CancellationToken)"/>
    Task<HttpResponse<ScheduledEventListPage>> List(
        string assistantID,
        ScheduledEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}/scheduled_events/{event_id}</c>, but is otherwise the
/// same as <see cref="IScheduledEventService.Delete(ScheduledEventDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ScheduledEventDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string eventID,
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}