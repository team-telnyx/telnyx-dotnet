using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Queues;
using Queues = Telnyx.Sdk.Services.Queues;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Queue commands operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IQueueService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IQueueServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Queues::ICallService Calls { get; }

    /// <summary>
/// Creates a new call queue with the provided configuration and returns the created
/// queue.
/// </summary>
    Task<QueueCreateResponse> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of an existing call queue, including its current
/// configuration.
/// </summary>
    Task<QueueRetrieveResponse> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(QueueRetrieveParams, CancellationToken)"/>
    Task<QueueRetrieveResponse> Retrieve(
        string queueName,
        QueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update properties of an existing call queue.
/// </summary>
    Task<QueueUpdateResponse> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(QueueUpdateParams, CancellationToken)"/>
    Task<QueueUpdateResponse> Update(
        string queueName,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all queues for the authenticated user.
/// </summary>
    Task<QueueListPage> List(
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified call queue from your account.
/// </summary>
    Task Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(QueueDeleteParams, CancellationToken)"/>
    Task Delete(
        string queueName,
        QueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IQueueService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IQueueServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Queues::ICallServiceWithRawResponse Calls { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /queues</c>, but is otherwise the
/// same as <see cref="IQueueService.Create(QueueCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueCreateResponse>> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /queues/{queue_name}</c>, but is otherwise the
/// same as <see cref="IQueueService.Retrieve(QueueRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueRetrieveResponse>> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(QueueRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<QueueRetrieveResponse>> Retrieve(
        string queueName,
        QueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /queues/{queue_name}</c>, but is otherwise the
/// same as <see cref="IQueueService.Update(QueueUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueUpdateResponse>> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(QueueUpdateParams, CancellationToken)"/>
    Task<HttpResponse<QueueUpdateResponse>> Update(
        string queueName,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /queues</c>, but is otherwise the
/// same as <see cref="IQueueService.List(QueueListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueListPage>> List(
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /queues/{queue_name}</c>, but is otherwise the
/// same as <see cref="IQueueService.Delete(QueueDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(QueueDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string queueName,
        QueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}