using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Portouts.Events;

namespace Telnyx.Sdk.Services.Portouts;

/// <summary>
/// Number portout operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
/// Returns the details of a single port-out event, including its type and payload.
/// </summary>
    Task<EventRetrieveResponse> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<EventRetrieveResponse> Retrieve(
        string id,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of port-out events on your account, such as status
/// changes on port-out requests, with support for filtering.
/// </summary>
    Task<EventListPage> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Republishes the specified port-out event, triggering re-delivery of the
/// corresponding webhook to your account.
/// </summary>
    Task Republish(
        EventRepublishParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Republish(EventRepublishParams, CancellationToken)"/>
    Task Republish(
        string id,
        EventRepublishParams? parameters = null,
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
/// Returns a raw HTTP response for <c>get /portouts/events/{id}</c>, but is otherwise the
/// same as <see cref="IEventService.Retrieve(EventRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EventRetrieveResponse>> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EventRetrieveResponse>> Retrieve(
        string id,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /portouts/events</c>, but is otherwise the
/// same as <see cref="IEventService.List(EventListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EventListPage>> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /portouts/events/{id}/republish</c>, but is otherwise the
/// same as <see cref="IEventService.Republish(EventRepublishParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Republish(
        EventRepublishParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Republish(EventRepublishParams, CancellationToken)"/>
    Task<HttpResponse> Republish(
        string id,
        EventRepublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}