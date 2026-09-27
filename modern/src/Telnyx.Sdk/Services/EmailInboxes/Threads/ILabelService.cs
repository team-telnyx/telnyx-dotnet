using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads.Labels;

namespace Telnyx.Sdk.Services.EmailInboxes.Threads;

/// <summary>
/// Create and manage agent inboxes, retrieve inbound messages and threads, and reply
/// to or forward messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILabelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILabelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILabelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Adds one or more mutable labels to a thread, letting an agent mark a whole
/// conversation (for example `needs_review`) without labelling each message
/// individually.
/// 
/// <para>Thread labels are independent of message labels: labelling a thread does
/// not label its messages, and labelling a message does not label its thread.
/// Idempotent and case-sensitive. </para>
/// </summary>
    Task<LabelCreateResponse> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(LabelCreateParams, CancellationToken)"/>
    Task<LabelCreateResponse> Create(
        string threadID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes one or more labels from a thread. Idempotent — removing a label the
/// thread does not carry is a no-op and still returns 200.
/// </summary>
    Task<LabelDeleteAllResponse> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(LabelDeleteAllParams, CancellationToken)"/>
    Task<LabelDeleteAllResponse> DeleteAll(
        string threadID,
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ILabelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILabelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILabelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/threads/{thread_id}/labels</c>, but is otherwise the
/// same as <see cref="ILabelService.Create(LabelCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LabelCreateResponse>> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(LabelCreateParams, CancellationToken)"/>
    Task<HttpResponse<LabelCreateResponse>> Create(
        string threadID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_inboxes/{inbox_id}/threads/{thread_id}/labels</c>, but is otherwise the
/// same as <see cref="ILabelService.DeleteAll(LabelDeleteAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(LabelDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        string threadID,
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}