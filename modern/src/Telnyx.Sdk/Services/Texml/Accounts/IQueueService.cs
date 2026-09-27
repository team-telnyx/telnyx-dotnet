using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Queues;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <summary>
/// TeXML REST Commands
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

    /// <summary>
/// Creates a new queue resource for the account with the provided settings and
/// returns it.
/// </summary>
    Task<QueueResource> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(QueueCreateParams, CancellationToken)"/>
    Task<QueueResource> Create(
        string accountSid,
        QueueCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a single queue resource for the account by its QueueSid.
/// </summary>
    Task<QueueResource> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(QueueRetrieveParams, CancellationToken)"/>
    Task<QueueResource> Retrieve(
        string queueSid,
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified queue resource's settings and returns the updated queue.
/// </summary>
    Task<QueueResource> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(QueueUpdateParams, CancellationToken)"/>
    Task<QueueResource> Update(
        string queueSid,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of queue resources for the account, with support for
/// filtering by creation or update dates.
/// </summary>
    Task<QueueListPage> List(
        QueueListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(QueueListParams, CancellationToken)"/>
    Task<QueueListPage> List(
        string accountSid,
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified queue resource from the account.
/// </summary>
    Task Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(QueueDeleteParams, CancellationToken)"/>
    Task Delete(
        string queueSid,
        QueueDeleteParams parameters,
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

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Queues</c>, but is otherwise the
/// same as <see cref="IQueueService.Create(QueueCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueResource>> Create(
        QueueCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(QueueCreateParams, CancellationToken)"/>
    Task<HttpResponse<QueueResource>> Create(
        string accountSid,
        QueueCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Queues/{queue_sid}</c>, but is otherwise the
/// same as <see cref="IQueueService.Retrieve(QueueRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueResource>> Retrieve(
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(QueueRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<QueueResource>> Retrieve(
        string queueSid,
        QueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Queues/{queue_sid}</c>, but is otherwise the
/// same as <see cref="IQueueService.Update(QueueUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueResource>> Update(
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(QueueUpdateParams, CancellationToken)"/>
    Task<HttpResponse<QueueResource>> Update(
        string queueSid,
        QueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Queues</c>, but is otherwise the
/// same as <see cref="IQueueService.List(QueueListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<QueueListPage>> List(
        QueueListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(QueueListParams, CancellationToken)"/>
    Task<HttpResponse<QueueListPage>> List(
        string accountSid,
        QueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /texml/Accounts/{account_sid}/Queues/{queue_sid}</c>, but is otherwise the
/// same as <see cref="IQueueService.Delete(QueueDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(QueueDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string queueSid,
        QueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}