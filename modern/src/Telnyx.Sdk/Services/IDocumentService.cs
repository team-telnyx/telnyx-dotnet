using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Documents;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Documents
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the details of a single document on your account, including its
/// metadata.
/// </summary>
    Task<DocumentRetrieveResponse> Retrieve(
        DocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DocumentRetrieveParams, CancellationToken)"/>
    Task<DocumentRetrieveResponse> Retrieve(
        string id,
        DocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified document's attributes and returns the updated document.
/// </summary>
    Task<DocumentUpdateResponse> Update(
        DocumentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DocumentUpdateParams, CancellationToken)"/>
    Task<DocumentUpdateResponse> Update(
        string documentID,
        DocumentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all documents ordered by created_at descending.
/// </summary>
    Task<DocumentListPage> List(
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a document.&lt;br /&gt;&lt;br /&gt;A document can only be deleted if it's
/// not linked to a service. If it is linked to a service, it must be unlinked prior
/// to deleting.
/// </summary>
    Task<DocumentDeleteResponse> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    Task<DocumentDeleteResponse> Delete(
        string id,
        DocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Downloads the raw file content of the specified document as originally uploaded.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Download(
        DocumentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(DocumentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        DocumentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Generates a temporary pre-signed URL that can be used to download the document
/// directly from the storage backend without authentication.
/// </summary>
    Task<DocumentGenerateDownloadLinkResponse> GenerateDownloadLink(
        DocumentGenerateDownloadLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateDownloadLink(DocumentGenerateDownloadLinkParams, CancellationToken)"/>
    Task<DocumentGenerateDownloadLinkResponse> GenerateDownloadLink(
        string id,
        DocumentGenerateDownloadLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Upload a document.&lt;br /&gt;&lt;br /&gt;Uploaded files must be linked to a
/// service within 30 minutes or they will be automatically deleted.
/// </summary>
    Task<DocumentUploadResponse> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Upload a document.&lt;br /&gt;&lt;br /&gt;Uploaded files must be linked to a
/// service within 30 minutes or they will be automatically deleted.
/// </summary>
    Task<DocumentUploadJsonResponse> UploadJson(
        DocumentUploadJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /documents/{id}</c>, but is otherwise the
/// same as <see cref="IDocumentService.Retrieve(DocumentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentRetrieveResponse>> Retrieve(
        DocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DocumentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DocumentRetrieveResponse>> Retrieve(
        string id,
        DocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /documents/{id}</c>, but is otherwise the
/// same as <see cref="IDocumentService.Update(DocumentUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentUpdateResponse>> Update(
        DocumentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DocumentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DocumentUpdateResponse>> Update(
        string documentID,
        DocumentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /documents</c>, but is otherwise the
/// same as <see cref="IDocumentService.List(DocumentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentListPage>> List(
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /documents/{id}</c>, but is otherwise the
/// same as <see cref="IDocumentService.Delete(DocumentDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentDeleteResponse>> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DocumentDeleteResponse>> Delete(
        string id,
        DocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /documents/{id}/download</c>, but is otherwise the
/// same as <see cref="IDocumentService.Download(DocumentDownloadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Download(
        DocumentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(DocumentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        DocumentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /documents/{id}/download_link</c>, but is otherwise the
/// same as <see cref="IDocumentService.GenerateDownloadLink(DocumentGenerateDownloadLinkParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentGenerateDownloadLinkResponse>> GenerateDownloadLink(
        DocumentGenerateDownloadLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateDownloadLink(DocumentGenerateDownloadLinkParams, CancellationToken)"/>
    Task<HttpResponse<DocumentGenerateDownloadLinkResponse>> GenerateDownloadLink(
        string id,
        DocumentGenerateDownloadLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /documents?content-type=multipart</c>, but is otherwise the
/// same as <see cref="IDocumentService.Upload(DocumentUploadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentUploadResponse>> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /documents</c>, but is otherwise the
/// same as <see cref="IDocumentService.UploadJson(DocumentUploadJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentUploadJsonResponse>> UploadJson(
        DocumentUploadJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}