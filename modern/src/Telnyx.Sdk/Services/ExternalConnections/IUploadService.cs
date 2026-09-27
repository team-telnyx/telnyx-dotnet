using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections.Uploads;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <summary>
/// External Connections operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUploadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUploadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new Upload request to Microsoft teams with the included phone numbers.
/// Only one of civic_address_id or location_id must be provided, not both. The
/// maximum allowed phone numbers for the numbers_ids array is 1000.
/// </summary>
    Task<UploadCreateResponse> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(UploadCreateParams, CancellationToken)"/>
    Task<UploadCreateResponse> Create(
        string id,
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the details of an Upload request and its phone numbers.
/// </summary>
    Task<UploadRetrieveResponse> Retrieve(
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UploadRetrieveParams, CancellationToken)"/>
    Task<UploadRetrieveResponse> Retrieve(
        string ticketID,
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your Upload requests for the given external connection.
/// </summary>
    Task<UploadListPage> List(
        UploadListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(UploadListParams, CancellationToken)"/>
    Task<UploadListPage> List(
        string id,
        UploadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the count of all pending upload requests for the given external
/// connection.
/// </summary>
    Task<UploadPendingCountResponse> PendingCount(
        UploadPendingCountParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PendingCount(UploadPendingCountParams, CancellationToken)"/>
    Task<UploadPendingCountResponse> PendingCount(
        string id,
        UploadPendingCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Forces a recheck of the status of all pending Upload requests for the given
/// external connection in the background.
/// </summary>
    Task<UploadRefreshStatusResponse> RefreshStatus(
        UploadRefreshStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RefreshStatus(UploadRefreshStatusParams, CancellationToken)"/>
    Task<UploadRefreshStatusResponse> RefreshStatus(
        string id,
        UploadRefreshStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// If there were any errors during the upload process, this endpoint will retry the
/// upload request. In some cases this will reattempt the existing upload request,
/// in other cases it may create a new upload request. Please check the ticket_id in
/// the response to determine if a new upload request was created.
/// </summary>
    Task<UploadRetryResponse> Retry(
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retry(UploadRetryParams, CancellationToken)"/>
    Task<UploadRetryResponse> Retry(
        string ticketID,
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUploadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUploadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /external_connections/{id}/uploads</c>, but is otherwise the
/// same as <see cref="IUploadService.Create(UploadCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadCreateResponse>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(UploadCreateParams, CancellationToken)"/>
    Task<HttpResponse<UploadCreateResponse>> Create(
        string id,
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/uploads/{ticket_id}</c>, but is otherwise the
/// same as <see cref="IUploadService.Retrieve(UploadRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadRetrieveResponse>> Retrieve(
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UploadRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UploadRetrieveResponse>> Retrieve(
        string ticketID,
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/uploads</c>, but is otherwise the
/// same as <see cref="IUploadService.List(UploadListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadListPage>> List(
        UploadListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(UploadListParams, CancellationToken)"/>
    Task<HttpResponse<UploadListPage>> List(
        string id,
        UploadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/uploads/status</c>, but is otherwise the
/// same as <see cref="IUploadService.PendingCount(UploadPendingCountParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadPendingCountResponse>> PendingCount(
        UploadPendingCountParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PendingCount(UploadPendingCountParams, CancellationToken)"/>
    Task<HttpResponse<UploadPendingCountResponse>> PendingCount(
        string id,
        UploadPendingCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /external_connections/{id}/uploads/refresh</c>, but is otherwise the
/// same as <see cref="IUploadService.RefreshStatus(UploadRefreshStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadRefreshStatusResponse>> RefreshStatus(
        UploadRefreshStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RefreshStatus(UploadRefreshStatusParams, CancellationToken)"/>
    Task<HttpResponse<UploadRefreshStatusResponse>> RefreshStatus(
        string id,
        UploadRefreshStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /external_connections/{id}/uploads/{ticket_id}/retry</c>, but is otherwise the
/// same as <see cref="IUploadService.Retry(UploadRetryParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UploadRetryResponse>> Retry(
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retry(UploadRetryParams, CancellationToken)"/>
    Task<HttpResponse<UploadRetryResponse>> Retry(
        string ticketID,
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}