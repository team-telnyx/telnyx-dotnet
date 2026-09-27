using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Portouts;
using Portouts = Telnyx.Sdk.Services.Portouts;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number portout operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPortoutService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPortoutServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortoutService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Portouts::IEventService Events { get; }

    Portouts::IReportService Reports { get; }

    Portouts::ICommentService Comments { get; }

    Portouts::ISupportingDocumentService SupportingDocuments { get; }

    /// <summary>
/// Returns the portout request based on the ID provided
/// </summary>
    Task<PortoutRetrieveResponse> Retrieve(
        PortoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PortoutRetrieveParams, CancellationToken)"/>
    Task<PortoutRetrieveResponse> Retrieve(
        string id,
        PortoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the portout requests according to filters
/// </summary>
    Task<PortoutListPage> List(
        PortoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Given a port-out ID, list rejection codes that are eligible for that port-out
/// </summary>
    Task<PortoutListRejectionCodesResponse> ListRejectionCodes(
        PortoutListRejectionCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListRejectionCodes(PortoutListRejectionCodesParams, CancellationToken)"/>
    Task<PortoutListRejectionCodesResponse> ListRejectionCodes(
        string portoutID,
        PortoutListRejectionCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the status of the specified port-out request, using the status path
/// segment to authorize or reject the port-out.
/// </summary>
    Task<PortoutUpdateStatusResponse> UpdateStatus(
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateStatus(PortoutUpdateStatusParams, CancellationToken)"/>
    Task<PortoutUpdateStatusResponse> UpdateStatus(
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status,
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPortoutService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPortoutServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortoutServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Portouts::IEventServiceWithRawResponse Events { get; }

    Portouts::IReportServiceWithRawResponse Reports { get; }

    Portouts::ICommentServiceWithRawResponse Comments { get; }

    Portouts::ISupportingDocumentServiceWithRawResponse SupportingDocuments {
        get;
    }

    /// <summary>
/// Returns a raw HTTP response for <c>get /portouts/{id}</c>, but is otherwise the
/// same as <see cref="IPortoutService.Retrieve(PortoutRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortoutRetrieveResponse>> Retrieve(
        PortoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PortoutRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PortoutRetrieveResponse>> Retrieve(
        string id,
        PortoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /portouts</c>, but is otherwise the
/// same as <see cref="IPortoutService.List(PortoutListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortoutListPage>> List(
        PortoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /portouts/rejections/{portout_id}</c>, but is otherwise the
/// same as <see cref="IPortoutService.ListRejectionCodes(PortoutListRejectionCodesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortoutListRejectionCodesResponse>> ListRejectionCodes(
        PortoutListRejectionCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListRejectionCodes(PortoutListRejectionCodesParams, CancellationToken)"/>
    Task<HttpResponse<PortoutListRejectionCodesResponse>> ListRejectionCodes(
        string portoutID,
        PortoutListRejectionCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /portouts/{id}/{status}</c>, but is otherwise the
/// same as <see cref="IPortoutService.UpdateStatus(PortoutUpdateStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortoutUpdateStatusResponse>> UpdateStatus(
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateStatus(PortoutUpdateStatusParams, CancellationToken)"/>
    Task<HttpResponse<PortoutUpdateStatusResponse>> UpdateStatus(
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status,
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}