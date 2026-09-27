using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallEvents;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Call Control debugging
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Filters call events by given filter parameters. Events are ordered by
/// `occurred_at`. If filter for `leg_id` or `application_session_id` is not
/// present, it only filters events from the last 24 hours.
/// 
/// <para>**Note**: Only one `filter[occurred_at]` can be passed. </para>
/// </summary>
    Task<CallEventListPage> List(
        CallEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /call_events</c>, but is otherwise the
/// same as <see cref="ICallEventService.List(CallEventListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallEventListPage>> List(
        CallEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}