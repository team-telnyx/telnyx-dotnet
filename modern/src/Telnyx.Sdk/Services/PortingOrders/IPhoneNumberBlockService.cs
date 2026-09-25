using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberBlockService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberBlockServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a phone number block on the porting order, representing a contiguous
/// range of phone numbers to be ported together.
/// </summary>
    Task<PhoneNumberBlockCreateResponse> Create(
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PhoneNumberBlockCreateParams, CancellationToken)"/>
    Task<PhoneNumberBlockCreateResponse> Create(
        string portingOrderID,
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all phone number blocks of a porting order.
/// </summary>
    Task<PhoneNumberBlockListPage> List(
        PhoneNumberBlockListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberBlockListParams, CancellationToken)"/>
    Task<PhoneNumberBlockListPage> List(
        string portingOrderID,
        PhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified phone number block from the porting order.
/// </summary>
    Task<PhoneNumberBlockDeleteResponse> Delete(
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberBlockDeleteParams, CancellationToken)"/>
    Task<PhoneNumberBlockDeleteResponse> Delete(
        string id,
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberBlockService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberBlockServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{porting_order_id}/phone_number_blocks</c>, but is otherwise the
/// same as <see cref="IPhoneNumberBlockService.Create(PhoneNumberBlockCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberBlockCreateResponse>> Create(
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PhoneNumberBlockCreateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberBlockCreateResponse>> Create(
        string portingOrderID,
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{porting_order_id}/phone_number_blocks</c>, but is otherwise the
/// same as <see cref="IPhoneNumberBlockService.List(PhoneNumberBlockListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberBlockListPage>> List(
        PhoneNumberBlockListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberBlockListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberBlockListPage>> List(
        string portingOrderID,
        PhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting_orders/{porting_order_id}/phone_number_blocks/{id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberBlockService.Delete(PhoneNumberBlockDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberBlockDeleteResponse>> Delete(
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberBlockDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberBlockDeleteResponse>> Delete(
        string id,
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}