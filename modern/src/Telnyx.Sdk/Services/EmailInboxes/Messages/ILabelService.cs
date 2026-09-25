using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Messages.Labels;

namespace Telnyx.Sdk.Services.EmailInboxes.Messages;

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
/// Adds one or more mutable labels to a message. Labels carry agent workflow state
/// such as `spam`, `needs_review`, or `processed`.
/// 
/// <para>Labels are **not** the same as the send-time `tags` on outbound messages:
/// `tags` are immutable and propagate to Email Detail Records and Mission Control
/// for billing attribution, while labels are mailbox state that never reaches the
/// reporting contract.</para>
/// 
/// <para>The operation is an idempotent set union — adding a label the message
/// already carries is a no-op and still returns 200. Labels are case-sensitive, and
/// message labels are independent of thread labels. </para>
/// </summary>
    Task<LabelCreateResponse> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(LabelCreateParams, CancellationToken)"/>
    Task<LabelCreateResponse> Create(
        string messageID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes one or more labels from a message. Idempotent — removing a label the
/// message does not carry is a no-op and still returns 200. Removal is
/// case-sensitive.
/// </summary>
    Task<LabelDeleteAllResponse> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(LabelDeleteAllParams, CancellationToken)"/>
    Task<LabelDeleteAllResponse> DeleteAll(
        string messageID,
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
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/messages/{message_id}/labels</c>, but is otherwise the
/// same as <see cref="ILabelService.Create(LabelCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LabelCreateResponse>> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(LabelCreateParams, CancellationToken)"/>
    Task<HttpResponse<LabelCreateResponse>> Create(
        string messageID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_inboxes/{inbox_id}/messages/{message_id}/labels</c>, but is otherwise the
/// same as <see cref="ILabelService.DeleteAll(LabelDeleteAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(LabelDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        string messageID,
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}