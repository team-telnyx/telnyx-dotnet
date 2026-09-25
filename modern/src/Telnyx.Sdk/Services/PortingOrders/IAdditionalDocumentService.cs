using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAdditionalDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAdditionalDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdditionalDocumentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a list of additional documents for a porting order.
/// </summary>
    Task<AdditionalDocumentCreateResponse> Create(
        AdditionalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AdditionalDocumentCreateParams, CancellationToken)"/>
    Task<AdditionalDocumentCreateResponse> Create(
        string id,
        AdditionalDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of additional documents for a porting order.
/// </summary>
    Task<AdditionalDocumentListPage> List(
        AdditionalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AdditionalDocumentListParams, CancellationToken)"/>
    Task<AdditionalDocumentListPage> List(
        string id,
        AdditionalDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an additional document for a porting order.
/// </summary>
    Task Delete(
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AdditionalDocumentDeleteParams, CancellationToken)"/>
    Task Delete(
        string additionalDocumentID,
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAdditionalDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAdditionalDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdditionalDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/additional_documents</c>, but is otherwise the
/// same as <see cref="IAdditionalDocumentService.Create(AdditionalDocumentCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdditionalDocumentCreateResponse>> Create(
        AdditionalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AdditionalDocumentCreateParams, CancellationToken)"/>
    Task<HttpResponse<AdditionalDocumentCreateResponse>> Create(
        string id,
        AdditionalDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/additional_documents</c>, but is otherwise the
/// same as <see cref="IAdditionalDocumentService.List(AdditionalDocumentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdditionalDocumentListPage>> List(
        AdditionalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AdditionalDocumentListParams, CancellationToken)"/>
    Task<HttpResponse<AdditionalDocumentListPage>> List(
        string id,
        AdditionalDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting_orders/{id}/additional_documents/{additional_document_id}</c>, but is otherwise the
/// same as <see cref="IAdditionalDocumentService.Delete(AdditionalDocumentDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AdditionalDocumentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string additionalDocumentID,
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}