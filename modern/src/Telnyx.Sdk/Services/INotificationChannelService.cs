using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationChannels;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Notification settings operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotificationChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationChannelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new notification channel defining where notifications are delivered,
/// and returns the created channel.
/// </summary>
    Task<NotificationChannelCreateResponse> Create(
        NotificationChannelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single notification channel by its identifier.
/// </summary>
    Task<NotificationChannelRetrieveResponse> Retrieve(
        NotificationChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationChannelRetrieveParams, CancellationToken)"/>
    Task<NotificationChannelRetrieveResponse> Retrieve(
        string id,
        NotificationChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified notification channel and returns the updated channel.
/// </summary>
    Task<NotificationChannelUpdateResponse> Update(
        NotificationChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NotificationChannelUpdateParams, CancellationToken)"/>
    Task<NotificationChannelUpdateResponse> Update(
        string notificationChannelID,
        NotificationChannelUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your notification channels, the destinations that
/// receive notifications.
/// </summary>
    Task<NotificationChannelListPage> List(
        NotificationChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified notification channel so notifications are no longer
/// delivered to it.
/// </summary>
    Task<NotificationChannelDeleteResponse> Delete(
        NotificationChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationChannelDeleteParams, CancellationToken)"/>
    Task<NotificationChannelDeleteResponse> Delete(
        string id,
        NotificationChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INotificationChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationChannelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /notification_channels</c>, but is otherwise the
/// same as <see cref="INotificationChannelService.Create(NotificationChannelCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationChannelCreateResponse>> Create(
        NotificationChannelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_channels/{id}</c>, but is otherwise the
/// same as <see cref="INotificationChannelService.Retrieve(NotificationChannelRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationChannelRetrieveResponse>> Retrieve(
        NotificationChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationChannelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NotificationChannelRetrieveResponse>> Retrieve(
        string id,
        NotificationChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /notification_channels/{id}</c>, but is otherwise the
/// same as <see cref="INotificationChannelService.Update(NotificationChannelUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationChannelUpdateResponse>> Update(
        NotificationChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NotificationChannelUpdateParams, CancellationToken)"/>
    Task<HttpResponse<NotificationChannelUpdateResponse>> Update(
        string notificationChannelID,
        NotificationChannelUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_channels</c>, but is otherwise the
/// same as <see cref="INotificationChannelService.List(NotificationChannelListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationChannelListPage>> List(
        NotificationChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /notification_channels/{id}</c>, but is otherwise the
/// same as <see cref="INotificationChannelService.Delete(NotificationChannelDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationChannelDeleteResponse>> Delete(
        NotificationChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationChannelDeleteParams, CancellationToken)"/>
    Task<HttpResponse<NotificationChannelDeleteResponse>> Delete(
        string id,
        NotificationChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}