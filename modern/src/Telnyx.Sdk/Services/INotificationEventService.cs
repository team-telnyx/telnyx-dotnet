using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationEvents;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Notification settings operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotificationEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a list of your notifications events.
/// </summary>
    Task<NotificationEventListPage> List(
        NotificationEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INotificationEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_events</c>, but is otherwise the
/// same as <see cref="INotificationEventService.List(NotificationEventListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationEventListPage>> List(
        NotificationEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}