using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationEventConditions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Notification settings operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotificationEventConditionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationEventConditionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationEventConditionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a list of your notifications events conditions.
/// </summary>
    Task<NotificationEventConditionListPage> List(
        NotificationEventConditionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INotificationEventConditionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationEventConditionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationEventConditionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_event_conditions</c>, but is otherwise the
/// same as <see cref="INotificationEventConditionService.List(NotificationEventConditionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationEventConditionListPage>> List(
        NotificationEventConditionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}