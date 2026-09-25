using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationSettings;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Notification settings operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotificationSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationSettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Adds a notification setting that enables delivery of a notification event type
/// to a notification profile.
/// </summary>
    Task<NotificationSettingCreateResponse> Create(
        NotificationSettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single notification setting by its identifier.
/// </summary>
    Task<NotificationSettingRetrieveResponse> Retrieve(
        NotificationSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationSettingRetrieveParams, CancellationToken)"/>
    Task<NotificationSettingRetrieveResponse> Retrieve(
        string id,
        NotificationSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your notification settings, which map notification
/// event types to profiles and channels.
/// </summary>
    Task<NotificationSettingListPage> List(
        NotificationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified notification setting, disabling that notification
/// delivery.
/// </summary>
    Task<NotificationSettingDeleteResponse> Delete(
        NotificationSettingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationSettingDeleteParams, CancellationToken)"/>
    Task<NotificationSettingDeleteResponse> Delete(
        string id,
        NotificationSettingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INotificationSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /notification_settings</c>, but is otherwise the
/// same as <see cref="INotificationSettingService.Create(NotificationSettingCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationSettingCreateResponse>> Create(
        NotificationSettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_settings/{id}</c>, but is otherwise the
/// same as <see cref="INotificationSettingService.Retrieve(NotificationSettingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationSettingRetrieveResponse>> Retrieve(
        NotificationSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationSettingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NotificationSettingRetrieveResponse>> Retrieve(
        string id,
        NotificationSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_settings</c>, but is otherwise the
/// same as <see cref="INotificationSettingService.List(NotificationSettingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationSettingListPage>> List(
        NotificationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /notification_settings/{id}</c>, but is otherwise the
/// same as <see cref="INotificationSettingService.Delete(NotificationSettingDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationSettingDeleteResponse>> Delete(
        NotificationSettingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationSettingDeleteParams, CancellationToken)"/>
    Task<HttpResponse<NotificationSettingDeleteResponse>> Delete(
        string id,
        NotificationSettingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}