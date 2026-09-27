using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAssociatedPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAssociatedPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssociatedPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new associated phone number for a porting order. This is used for
/// partial porting in GB to specify which phone numbers should be kept or
/// disconnected.
/// </summary>
    Task<AssociatedPhoneNumberCreateResponse> Create(
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AssociatedPhoneNumberCreateParams, CancellationToken)"/>
    Task<AssociatedPhoneNumberCreateResponse> Create(
        string portingOrderID,
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all associated phone numbers for a porting order. Associated
/// phone numbers are used for partial porting in GB to specify which phone numbers
/// should be kept or disconnected.
/// </summary>
    Task<AssociatedPhoneNumberListPage> List(
        AssociatedPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AssociatedPhoneNumberListParams, CancellationToken)"/>
    Task<AssociatedPhoneNumberListPage> List(
        string portingOrderID,
        AssociatedPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an associated phone number from a porting order.
/// </summary>
    Task<AssociatedPhoneNumberDeleteResponse> Delete(
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AssociatedPhoneNumberDeleteParams, CancellationToken)"/>
    Task<AssociatedPhoneNumberDeleteResponse> Delete(
        string id,
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAssociatedPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAssociatedPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssociatedPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{porting_order_id}/associated_phone_numbers</c>, but is otherwise the
/// same as <see cref="IAssociatedPhoneNumberService.Create(AssociatedPhoneNumberCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssociatedPhoneNumberCreateResponse>> Create(
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AssociatedPhoneNumberCreateParams, CancellationToken)"/>
    Task<HttpResponse<AssociatedPhoneNumberCreateResponse>> Create(
        string portingOrderID,
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{porting_order_id}/associated_phone_numbers</c>, but is otherwise the
/// same as <see cref="IAssociatedPhoneNumberService.List(AssociatedPhoneNumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssociatedPhoneNumberListPage>> List(
        AssociatedPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AssociatedPhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<AssociatedPhoneNumberListPage>> List(
        string portingOrderID,
        AssociatedPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting_orders/{porting_order_id}/associated_phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IAssociatedPhoneNumberService.Delete(AssociatedPhoneNumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssociatedPhoneNumberDeleteResponse>> Delete(
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AssociatedPhoneNumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AssociatedPhoneNumberDeleteResponse>> Delete(
        string id,
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}