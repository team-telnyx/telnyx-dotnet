using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailThreads;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Account-wide conversation threads across every inbox, for agents operating many
/// inboxes at once.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailThreadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailThreadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailThreadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns a thread and a bounded page of its inbound and outbound messages,
/// interleaved in chronological order. The `inbox_id` returned by the list endpoint
/// is required because a thread ID can occur in multiple inboxes. Only messages
/// matching that `(inbox_id, thread_id)` pair are returned. Threads outside the
/// account return an opaque 404.
/// </summary>
    Task<EmailThreadRetrieveResponse> Retrieve(
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailThreadRetrieveParams, CancellationToken)"/>
    Task<EmailThreadRetrieveResponse> Retrieve(
        string threadID,
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists thread summaries for the whole account, newest first, using stable cursor
/// pagination. An agent operating many inboxes gets every conversation in one call
/// instead of one call per inbox. Each thread carries its own `inbox_id` so a reply
/// can be routed back to the right inbox. Use `filter[inbox_id]` (repeatable) to
/// narrow the result to specific inboxes. Because a thread ID can be delivered to
/// multiple inboxes, each result is identified by its `(inbox_id, id)` pair.
/// </summary>
    Task<EmailThreadListPage> List(
        EmailThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailThreadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailThreadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailThreadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_threads/{thread_id}</c>, but is otherwise the
/// same as <see cref="IEmailThreadService.Retrieve(EmailThreadRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailThreadRetrieveResponse>> Retrieve(
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailThreadRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailThreadRetrieveResponse>> Retrieve(
        string threadID,
        EmailThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_threads</c>, but is otherwise the
/// same as <see cref="IEmailThreadService.List(EmailThreadListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailThreadListPage>> List(
        EmailThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}