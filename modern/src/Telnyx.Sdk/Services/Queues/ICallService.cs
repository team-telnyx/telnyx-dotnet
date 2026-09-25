using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Queues.Calls;

namespace Telnyx.Sdk.Services.Queues;

/// <summary>
/// Queue commands operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve an existing call from an existing queue
/// </summary>
    Task<CallRetrieveResponse> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<CallRetrieveResponse> Retrieve(
        string callControlID,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update queued call's keep_after_hangup flag
/// </summary>
    Task Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallUpdateParams, CancellationToken)"/>
    Task Update(
        string callControlID,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the list of calls in an existing queue
/// </summary>
    Task<CallListPage> List(
        CallListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CallListParams, CancellationToken)"/>
    Task<CallListPage> List(
        string queueName,
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes an inactive call from a queue. If the call is no longer active, use this
/// command to remove it from the queue.
/// </summary>
    Task Remove(
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(CallRemoveParams, CancellationToken)"/>
    Task Remove(
        string callControlID,
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /queues/{queue_name}/calls/{call_control_id}</c>, but is otherwise the
/// same as <see cref="ICallService.Retrieve(CallRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        string callControlID,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /queues/{queue_name}/calls/{call_control_id}</c>, but is otherwise the
/// same as <see cref="ICallService.Update(CallUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string callControlID,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /queues/{queue_name}/calls</c>, but is otherwise the
/// same as <see cref="ICallService.List(CallListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallListPage>> List(
        CallListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CallListParams, CancellationToken)"/>
    Task<HttpResponse<CallListPage>> List(
        string queueName,
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /queues/{queue_name}/calls/{call_control_id}</c>, but is otherwise the
/// same as <see cref="ICallService.Remove(CallRemoveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Remove(
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(CallRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string callControlID,
        CallRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}