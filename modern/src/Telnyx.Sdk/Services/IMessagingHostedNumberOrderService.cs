using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingHostedNumberOrders;
using MessagingHostedNumberOrders = Telnyx.Sdk.Services.MessagingHostedNumberOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Manage your messaging hosted numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingHostedNumberOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingHostedNumberOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingHostedNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingHostedNumberOrders::IActionService Actions { get; }

    /// <summary>
/// Creates an order to enable Telnyx messaging on phone numbers whose voice service
/// remains with another carrier.
/// </summary>
    Task<MessagingHostedNumberOrderCreateResponse> Create(
        MessagingHostedNumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the current state, phone numbers, and required actions for the specified
/// hosted-messaging order.
/// </summary>
    Task<MessagingHostedNumberOrderRetrieveResponse> Retrieve(
        MessagingHostedNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingHostedNumberOrderRetrieveParams, CancellationToken)"/>
    Task<MessagingHostedNumberOrderRetrieveResponse> Retrieve(
        string id,
        MessagingHostedNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns hosted-messaging orders for the authenticated account. Apply the
/// documented filters and pagination parameters to narrow the result set.
/// </summary>
    Task<MessagingHostedNumberOrderListPage> List(
        MessagingHostedNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a messaging hosted number order and all associated phone numbers.
/// </summary>
    Task<MessagingHostedNumberOrderDeleteResponse> Delete(
        MessagingHostedNumberOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingHostedNumberOrderDeleteParams, CancellationToken)"/>
    Task<MessagingHostedNumberOrderDeleteResponse> Delete(
        string id,
        MessagingHostedNumberOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Checks whether the supplied phone numbers are eligible for hosted messaging
/// before an order is created.
/// </summary>
    Task<MessagingHostedNumberOrderCheckEligibilityResponse> CheckEligibility(
        MessagingHostedNumberOrderCheckEligibilityParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Create verification codes to validate numbers of the hosted order. The
/// verification codes will be sent to the numbers of the hosted order.
/// </summary>
    Task<MessagingHostedNumberOrderCreateVerificationCodesResponse> CreateVerificationCodes(
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateVerificationCodes(MessagingHostedNumberOrderCreateVerificationCodesParams, CancellationToken)"/>
    Task<MessagingHostedNumberOrderCreateVerificationCodesResponse> CreateVerificationCodes(
        string id,
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Validate the verification codes sent to the numbers of the hosted order. The
/// verification codes must be created in the verification codes endpoint.
/// </summary>
    Task<MessagingHostedNumberOrderValidateCodesResponse> ValidateCodes(
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ValidateCodes(MessagingHostedNumberOrderValidateCodesParams, CancellationToken)"/>
    Task<MessagingHostedNumberOrderValidateCodesResponse> ValidateCodes(
        string id,
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingHostedNumberOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingHostedNumberOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingHostedNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingHostedNumberOrders::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_hosted_number_orders</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.Create(MessagingHostedNumberOrderCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderCreateResponse>> Create(
        MessagingHostedNumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_hosted_number_orders/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.Retrieve(MessagingHostedNumberOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderRetrieveResponse>> Retrieve(
        MessagingHostedNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingHostedNumberOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberOrderRetrieveResponse>> Retrieve(
        string id,
        MessagingHostedNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_hosted_number_orders</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.List(MessagingHostedNumberOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderListPage>> List(
        MessagingHostedNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messaging_hosted_number_orders/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.Delete(MessagingHostedNumberOrderDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderDeleteResponse>> Delete(
        MessagingHostedNumberOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingHostedNumberOrderDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberOrderDeleteResponse>> Delete(
        string id,
        MessagingHostedNumberOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_hosted_number_orders/eligibility_numbers_check</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.CheckEligibility(MessagingHostedNumberOrderCheckEligibilityParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderCheckEligibilityResponse>> CheckEligibility(
        MessagingHostedNumberOrderCheckEligibilityParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_hosted_number_orders/{id}/verification_codes</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.CreateVerificationCodes(MessagingHostedNumberOrderCreateVerificationCodesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderCreateVerificationCodesResponse>> CreateVerificationCodes(
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateVerificationCodes(MessagingHostedNumberOrderCreateVerificationCodesParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberOrderCreateVerificationCodesResponse>> CreateVerificationCodes(
        string id,
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_hosted_number_orders/{id}/validation_codes</c>, but is otherwise the
/// same as <see cref="IMessagingHostedNumberOrderService.ValidateCodes(MessagingHostedNumberOrderValidateCodesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingHostedNumberOrderValidateCodesResponse>> ValidateCodes(
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ValidateCodes(MessagingHostedNumberOrderValidateCodesParams, CancellationToken)"/>
    Task<HttpResponse<MessagingHostedNumberOrderValidateCodesResponse>> ValidateCodes(
        string id,
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}