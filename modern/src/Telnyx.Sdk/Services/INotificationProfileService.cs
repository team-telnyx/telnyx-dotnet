using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NotificationProfiles;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Notification settings operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotificationProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new notification profile, a named grouping used to organize
/// notification settings, and returns it.
/// </summary>
    Task<NotificationProfileCreateResponse> Create(
        NotificationProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single notification profile by its identifier.
/// </summary>
    Task<NotificationProfileRetrieveResponse> Retrieve(
        NotificationProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationProfileRetrieveParams, CancellationToken)"/>
    Task<NotificationProfileRetrieveResponse> Retrieve(
        string id,
        NotificationProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified notification profile and returns the updated profile.
/// </summary>
    Task<NotificationProfileUpdateResponse> Update(
        NotificationProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NotificationProfileUpdateParams, CancellationToken)"/>
    Task<NotificationProfileUpdateResponse> Update(
        string notificationProfileID,
        NotificationProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your notifications profiles.
/// </summary>
    Task<NotificationProfileListPage> List(
        NotificationProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified notification profile from your account.
/// </summary>
    Task<NotificationProfileDeleteResponse> Delete(
        NotificationProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationProfileDeleteParams, CancellationToken)"/>
    Task<NotificationProfileDeleteResponse> Delete(
        string id,
        NotificationProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INotificationProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /notification_profiles</c>, but is otherwise the
/// same as <see cref="INotificationProfileService.Create(NotificationProfileCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationProfileCreateResponse>> Create(
        NotificationProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_profiles/{id}</c>, but is otherwise the
/// same as <see cref="INotificationProfileService.Retrieve(NotificationProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationProfileRetrieveResponse>> Retrieve(
        NotificationProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NotificationProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NotificationProfileRetrieveResponse>> Retrieve(
        string id,
        NotificationProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /notification_profiles/{id}</c>, but is otherwise the
/// same as <see cref="INotificationProfileService.Update(NotificationProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationProfileUpdateResponse>> Update(
        NotificationProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NotificationProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<NotificationProfileUpdateResponse>> Update(
        string notificationProfileID,
        NotificationProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /notification_profiles</c>, but is otherwise the
/// same as <see cref="INotificationProfileService.List(NotificationProfileListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationProfileListPage>> List(
        NotificationProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /notification_profiles/{id}</c>, but is otherwise the
/// same as <see cref="INotificationProfileService.Delete(NotificationProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NotificationProfileDeleteResponse>> Delete(
        NotificationProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NotificationProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<NotificationProfileDeleteResponse>> Delete(
        string id,
        NotificationProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}