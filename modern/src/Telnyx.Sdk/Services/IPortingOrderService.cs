using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders;
using PortingOrders = Telnyx.Sdk.Services.PortingOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPortingOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPortingOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    PortingOrders::IPhoneNumberConfigurationService PhoneNumberConfigurations {
        get;
    }

    PortingOrders::IActionService Actions { get; }

    PortingOrders::IActivationJobService ActivationJobs { get; }

    PortingOrders::IAdditionalDocumentService AdditionalDocuments { get; }

    PortingOrders::ICommentService Comments { get; }

    PortingOrders::IVerificationCodeService VerificationCodes { get; }

    PortingOrders::IActionRequirementService ActionRequirements { get; }

    PortingOrders::IAssociatedPhoneNumberService AssociatedPhoneNumbers { get; }

    PortingOrders::IPhoneNumberBlockService PhoneNumberBlocks { get; }

    PortingOrders::IPhoneNumberExtensionService PhoneNumberExtensions { get; }

    /// <summary>
/// Creates a new porting order to bring phone numbers from another carrier to
/// Telnyx. Complete the order's requirements and then confirm it to submit the
/// port.
/// </summary>
    Task<PortingOrderCreateResponse> Create(
        PortingOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing porting order.
/// </summary>
    Task<PortingOrderRetrieveResponse> Retrieve(
        PortingOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PortingOrderRetrieveParams, CancellationToken)"/>
    Task<PortingOrderRetrieveResponse> Retrieve(
        string id,
        PortingOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Edits the details of an existing porting order.
/// 
/// <para>Any or all of a porting orders attributes may be included in the resource
/// object included in a PATCH request.</para>
/// 
/// <para>If a request does not include all of the attributes for a resource, the
/// system will interpret the missing attributes as if they were included with their
/// current values. To explicitly set something to null, it must be included in the
/// request with a null value.</para>
/// </summary>
    Task<PortingOrderUpdateResponse> Update(
        PortingOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PortingOrderUpdateParams, CancellationToken)"/>
    Task<PortingOrderUpdateResponse> Update(
        string id,
        PortingOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your porting orders. Supports filtering and sorting,
/// and can optionally include the phone numbers attached to each order.
/// </summary>
    Task<PortingOrderListPage> List(
        PortingOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an existing porting order. This operation is restrict to porting orders
/// in draft state.
/// </summary>
    Task Delete(
        PortingOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PortingOrderDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        PortingOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of allowed FOC dates for a porting order.
/// </summary>
    Task<PortingOrderRetrieveAllowedFocWindowsResponse> RetrieveAllowedFocWindows(
        PortingOrderRetrieveAllowedFocWindowsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveAllowedFocWindows(PortingOrderRetrieveAllowedFocWindowsParams, CancellationToken)"/>
    Task<PortingOrderRetrieveAllowedFocWindowsResponse> RetrieveAllowedFocWindows(
        string id,
        PortingOrderRetrieveAllowedFocWindowsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all possible exception types for a porting order.
/// </summary>
    Task<PortingOrderRetrieveExceptionTypesResponse> RetrieveExceptionTypes(
        PortingOrderRetrieveExceptionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Downloads the Letter of Authorization (LOA) template document for this porting
/// order, optionally rendered with a specific LOA configuration.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> RetrieveLoaTemplate(
        PortingOrderRetrieveLoaTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveLoaTemplate(PortingOrderRetrieveLoaTemplateParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveLoaTemplate(
        string id,
        PortingOrderRetrieveLoaTemplateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all requirements based on country/number type for this porting
/// order.
/// </summary>
    Task<PortingOrderRetrieveRequirementsPage> RetrieveRequirements(
        PortingOrderRetrieveRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRequirements(PortingOrderRetrieveRequirementsParams, CancellationToken)"/>
    Task<PortingOrderRetrieveRequirementsPage> RetrieveRequirements(
        string id,
        PortingOrderRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the associated V1 sub_request_id and port_request_id
/// </summary>
    Task<PortingOrderRetrieveSubRequestResponse> RetrieveSubRequest(
        PortingOrderRetrieveSubRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSubRequest(PortingOrderRetrieveSubRequestParams, CancellationToken)"/>
    Task<PortingOrderRetrieveSubRequestResponse> RetrieveSubRequest(
        string id,
        PortingOrderRetrieveSubRequestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPortingOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPortingOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    PortingOrders::IPhoneNumberConfigurationServiceWithRawResponse PhoneNumberConfigurations {
        get;
    }

    PortingOrders::IActionServiceWithRawResponse Actions { get; }

    PortingOrders::IActivationJobServiceWithRawResponse ActivationJobs { get; }

    PortingOrders::IAdditionalDocumentServiceWithRawResponse AdditionalDocuments {
        get;
    }

    PortingOrders::ICommentServiceWithRawResponse Comments { get; }

    PortingOrders::IVerificationCodeServiceWithRawResponse VerificationCodes {
        get;
    }

    PortingOrders::IActionRequirementServiceWithRawResponse ActionRequirements {
        get;
    }

    PortingOrders::IAssociatedPhoneNumberServiceWithRawResponse AssociatedPhoneNumbers {
        get;
    }

    PortingOrders::IPhoneNumberBlockServiceWithRawResponse PhoneNumberBlocks {
        get;
    }

    PortingOrders::IPhoneNumberExtensionServiceWithRawResponse PhoneNumberExtensions {
        get;
    }

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.Create(PortingOrderCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderCreateResponse>> Create(
        PortingOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.Retrieve(PortingOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderRetrieveResponse>> Retrieve(
        PortingOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PortingOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PortingOrderRetrieveResponse>> Retrieve(
        string id,
        PortingOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /porting_orders/{id}</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.Update(PortingOrderUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderUpdateResponse>> Update(
        PortingOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PortingOrderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PortingOrderUpdateResponse>> Update(
        string id,
        PortingOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.List(PortingOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderListPage>> List(
        PortingOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting_orders/{id}</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.Delete(PortingOrderDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        PortingOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PortingOrderDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        PortingOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/allowed_foc_windows</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.RetrieveAllowedFocWindows(PortingOrderRetrieveAllowedFocWindowsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderRetrieveAllowedFocWindowsResponse>> RetrieveAllowedFocWindows(
        PortingOrderRetrieveAllowedFocWindowsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveAllowedFocWindows(PortingOrderRetrieveAllowedFocWindowsParams, CancellationToken)"/>
    Task<HttpResponse<PortingOrderRetrieveAllowedFocWindowsResponse>> RetrieveAllowedFocWindows(
        string id,
        PortingOrderRetrieveAllowedFocWindowsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/exception_types</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.RetrieveExceptionTypes(PortingOrderRetrieveExceptionTypesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderRetrieveExceptionTypesResponse>> RetrieveExceptionTypes(
        PortingOrderRetrieveExceptionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/loa_template</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.RetrieveLoaTemplate(PortingOrderRetrieveLoaTemplateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> RetrieveLoaTemplate(
        PortingOrderRetrieveLoaTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveLoaTemplate(PortingOrderRetrieveLoaTemplateParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveLoaTemplate(
        string id,
        PortingOrderRetrieveLoaTemplateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/requirements</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.RetrieveRequirements(PortingOrderRetrieveRequirementsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderRetrieveRequirementsPage>> RetrieveRequirements(
        PortingOrderRetrieveRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRequirements(PortingOrderRetrieveRequirementsParams, CancellationToken)"/>
    Task<HttpResponse<PortingOrderRetrieveRequirementsPage>> RetrieveRequirements(
        string id,
        PortingOrderRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/sub_request</c>, but is otherwise the
/// same as <see cref="IPortingOrderService.RetrieveSubRequest(PortingOrderRetrieveSubRequestParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingOrderRetrieveSubRequestResponse>> RetrieveSubRequest(
        PortingOrderRetrieveSubRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSubRequest(PortingOrderRetrieveSubRequestParams, CancellationToken)"/>
    Task<HttpResponse<PortingOrderRetrieveSubRequestResponse>> RetrieveSubRequest(
        string id,
        PortingOrderRetrieveSubRequestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}