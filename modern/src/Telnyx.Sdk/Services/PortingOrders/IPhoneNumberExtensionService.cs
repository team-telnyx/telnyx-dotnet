using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberExtensionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberExtensionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberExtensionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a phone number extension on the porting order, mapping extension ranges
/// to one of the order's phone numbers.
/// </summary>
    Task<PhoneNumberExtensionCreateResponse> Create(
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PhoneNumberExtensionCreateParams, CancellationToken)"/>
    Task<PhoneNumberExtensionCreateResponse> Create(
        string portingOrderID,
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all phone number extensions of a porting order.
/// </summary>
    Task<PhoneNumberExtensionListPage> List(
        PhoneNumberExtensionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberExtensionListParams, CancellationToken)"/>
    Task<PhoneNumberExtensionListPage> List(
        string portingOrderID,
        PhoneNumberExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified phone number extension from the porting order.
/// </summary>
    Task<PhoneNumberExtensionDeleteResponse> Delete(
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberExtensionDeleteParams, CancellationToken)"/>
    Task<PhoneNumberExtensionDeleteResponse> Delete(
        string id,
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberExtensionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberExtensionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberExtensionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{porting_order_id}/phone_number_extensions</c>, but is otherwise the
/// same as <see cref="IPhoneNumberExtensionService.Create(PhoneNumberExtensionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberExtensionCreateResponse>> Create(
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PhoneNumberExtensionCreateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberExtensionCreateResponse>> Create(
        string portingOrderID,
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{porting_order_id}/phone_number_extensions</c>, but is otherwise the
/// same as <see cref="IPhoneNumberExtensionService.List(PhoneNumberExtensionListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberExtensionListPage>> List(
        PhoneNumberExtensionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberExtensionListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberExtensionListPage>> List(
        string portingOrderID,
        PhoneNumberExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting_orders/{porting_order_id}/phone_number_extensions/{id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberExtensionService.Delete(PhoneNumberExtensionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberExtensionDeleteResponse>> Delete(
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberExtensionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberExtensionDeleteResponse>> Delete(
        string id,
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}