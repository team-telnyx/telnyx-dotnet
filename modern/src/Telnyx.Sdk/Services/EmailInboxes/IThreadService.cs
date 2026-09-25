using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;
using Telnyx.Sdk.Services.EmailInboxes.Threads;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <summary>
/// Create and manage agent inboxes, retrieve inbound messages and threads, and reply
/// to or forward messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IThreadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IThreadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IThreadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ILabelService Labels { get; }

    /// <summary>
/// Returns a bounded page of inbound and outbound thread messages interleaved in
/// chronological order using stable cursor pagination.
/// </summary>
    Task<ThreadRetrieveResponse> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ThreadRetrieveParams, CancellationToken)"/>
    Task<ThreadRetrieveResponse> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists thread summaries newest first using stable cursor pagination.
/// </summary>
    Task<ThreadListPage> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ThreadListParams, CancellationToken)"/>
    Task<ThreadListPage> List(
        string inboxID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IThreadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IThreadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IThreadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ILabelServiceWithRawResponse Labels { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/threads/{thread_id}</c>, but is otherwise the
/// same as <see cref="IThreadService.Retrieve(ThreadRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ThreadRetrieveResponse>> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ThreadRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ThreadRetrieveResponse>> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/threads</c>, but is otherwise the
/// same as <see cref="IThreadService.List(ThreadListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ThreadListPage>> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ThreadListParams, CancellationToken)"/>
    Task<HttpResponse<ThreadListPage>> List(
        string inboxID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}