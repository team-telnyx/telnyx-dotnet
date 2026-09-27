using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardDataUsageNotifications;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIM Cards operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISimCardDataUsageNotificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimCardDataUsageNotificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardDataUsageNotificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new SIM card data usage notification.
/// </summary>
    Task<SimCardDataUsageNotificationCreateResponse> Create(
        SimCardDataUsageNotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a single SIM Card Data Usage Notification.
/// </summary>
    Task<SimCardDataUsageNotificationRetrieveResponse> Retrieve(
        SimCardDataUsageNotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardDataUsageNotificationRetrieveParams, CancellationToken)"/>
    Task<SimCardDataUsageNotificationRetrieveResponse> Retrieve(
        string id,
        SimCardDataUsageNotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates information for a SIM Card Data Usage Notification.
/// </summary>
    Task<SimCardDataUsageNotificationUpdateResponse> Update(
        SimCardDataUsageNotificationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardDataUsageNotificationUpdateParams, CancellationToken)"/>
    Task<SimCardDataUsageNotificationUpdateResponse> Update(
        string simCardDataUsageNotificationID,
        SimCardDataUsageNotificationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists a paginated collection of SIM card data usage notifications. It enables
/// exploring the collection using specific filters.
/// </summary>
    Task<SimCardDataUsageNotificationListPage> List(
        SimCardDataUsageNotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete the SIM Card Data Usage Notification.
/// </summary>
    Task<SimCardDataUsageNotificationDeleteResponse> Delete(
        SimCardDataUsageNotificationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardDataUsageNotificationDeleteParams, CancellationToken)"/>
    Task<SimCardDataUsageNotificationDeleteResponse> Delete(
        string id,
        SimCardDataUsageNotificationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISimCardDataUsageNotificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimCardDataUsageNotificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardDataUsageNotificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_data_usage_notifications</c>, but is otherwise the
/// same as <see cref="ISimCardDataUsageNotificationService.Create(SimCardDataUsageNotificationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDataUsageNotificationCreateResponse>> Create(
        SimCardDataUsageNotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_data_usage_notifications/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardDataUsageNotificationService.Retrieve(SimCardDataUsageNotificationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDataUsageNotificationRetrieveResponse>> Retrieve(
        SimCardDataUsageNotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardDataUsageNotificationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SimCardDataUsageNotificationRetrieveResponse>> Retrieve(
        string id,
        SimCardDataUsageNotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /sim_card_data_usage_notifications/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardDataUsageNotificationService.Update(SimCardDataUsageNotificationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDataUsageNotificationUpdateResponse>> Update(
        SimCardDataUsageNotificationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SimCardDataUsageNotificationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SimCardDataUsageNotificationUpdateResponse>> Update(
        string simCardDataUsageNotificationID,
        SimCardDataUsageNotificationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_data_usage_notifications</c>, but is otherwise the
/// same as <see cref="ISimCardDataUsageNotificationService.List(SimCardDataUsageNotificationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDataUsageNotificationListPage>> List(
        SimCardDataUsageNotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /sim_card_data_usage_notifications/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardDataUsageNotificationService.Delete(SimCardDataUsageNotificationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardDataUsageNotificationDeleteResponse>> Delete(
        SimCardDataUsageNotificationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SimCardDataUsageNotificationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SimCardDataUsageNotificationDeleteResponse>> Delete(
        string id,
        SimCardDataUsageNotificationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}