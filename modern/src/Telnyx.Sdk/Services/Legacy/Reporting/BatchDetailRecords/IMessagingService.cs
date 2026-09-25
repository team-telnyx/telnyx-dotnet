using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

namespace Telnyx.Sdk.Services.Legacy.Reporting.BatchDetailRecords;

/// <summary>
/// Messaging batch detail records
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new MDR detailed report request with the specified filters
/// </summary>
    Task<MessagingCreateResponse> Create(
        MessagingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a specific MDR detailed report request by ID
/// </summary>
    Task<MessagingRetrieveResponse> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<MessagingRetrieveResponse> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves all MDR detailed report requests for the authenticated user
/// </summary>
    Task<MessagingListResponse> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a specific MDR detailed report request by ID
/// </summary>
    Task<MessagingDeleteResponse> Delete(
        MessagingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingDeleteParams, CancellationToken)"/>
    Task<MessagingDeleteResponse> Delete(
        string id,
        MessagingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /legacy/reporting/batch_detail_records/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.Create(MessagingCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingCreateResponse>> Create(
        MessagingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/batch_detail_records/messaging/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingService.Retrieve(MessagingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/batch_detail_records/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.List(MessagingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingListResponse>> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /legacy/reporting/batch_detail_records/messaging/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingService.Delete(MessagingDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingDeleteResponse>> Delete(
        MessagingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MessagingDeleteResponse>> Delete(
        string id,
        MessagingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}