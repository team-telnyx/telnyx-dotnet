using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

namespace Telnyx.Sdk.Services.MessagingTollfree.Verification;

/// <summary>
/// Manage your tollfree verification requests
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Submit a new tollfree verification request
/// </summary>
    Task<MessagingTollFreeVerificationVerificationRequestEgress> Create(
        RequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a single verification request by its ID.
/// </summary>
    Task<RequestRetrieveResponse> Retrieve(
        RequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequestRetrieveParams, CancellationToken)"/>
    Task<RequestRetrieveResponse> Retrieve(
        string id,
        RequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update an existing tollfree verification request. This is particularly useful
/// when there are pending customer actions to be taken.
/// </summary>
    Task<MessagingTollFreeVerificationVerificationRequestEgress> Update(
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RequestUpdateParams, CancellationToken)"/>
    Task<MessagingTollFreeVerificationVerificationRequestEgress> Update(
        string id,
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a list of previously-submitted tollfree verification requests
/// </summary>
    Task<RequestListPage> List(
        RequestListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a verification request
/// 
/// <para>A request may only be deleted when when the request is in the "rejected"
/// state.</para>
/// 
/// <para>* `HTTP 200`: request successfully deleted * `HTTP 400`: request exists
/// but can't be deleted (i.e. not rejected) * `HTTP 404`: request unknown or
/// already deleted</para>
/// </summary>
    Task Delete(
        RequestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RequestDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        RequestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the history of status changes for a verification request.
/// 
/// <para>Returns a paginated list of historical status changes including the reason
/// for each change and when it occurred.</para>
/// </summary>
    Task<RequestRetrieveStatusHistoryResponse> RetrieveStatusHistory(
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatusHistory(RequestRetrieveStatusHistoryParams, CancellationToken)"/>
    Task<RequestRetrieveStatusHistoryResponse> RetrieveStatusHistory(
        string id,
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_tollfree/verification/requests</c>, but is otherwise the
/// same as <see cref="IRequestService.Create(RequestCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Create(
        RequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_tollfree/verification/requests/{id}</c>, but is otherwise the
/// same as <see cref="IRequestService.Retrieve(RequestRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequestRetrieveResponse>> Retrieve(
        RequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RequestRetrieveResponse>> Retrieve(
        string id,
        RequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /messaging_tollfree/verification/requests/{id}</c>, but is otherwise the
/// same as <see cref="IRequestService.Update(RequestUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Update(
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RequestUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MessagingTollFreeVerificationVerificationRequestEgress>> Update(
        string id,
        RequestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_tollfree/verification/requests</c>, but is otherwise the
/// same as <see cref="IRequestService.List(RequestListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequestListPage>> List(
        RequestListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messaging_tollfree/verification/requests/{id}</c>, but is otherwise the
/// same as <see cref="IRequestService.Delete(RequestDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        RequestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RequestDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        RequestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_tollfree/verification/requests/{id}/status_history</c>, but is otherwise the
/// same as <see cref="IRequestService.RetrieveStatusHistory(RequestRetrieveStatusHistoryParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequestRetrieveStatusHistoryResponse>> RetrieveStatusHistory(
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatusHistory(RequestRetrieveStatusHistoryParams, CancellationToken)"/>
    Task<HttpResponse<RequestRetrieveStatusHistoryResponse>> RetrieveStatusHistory(
        string id,
        RequestRetrieveStatusHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}