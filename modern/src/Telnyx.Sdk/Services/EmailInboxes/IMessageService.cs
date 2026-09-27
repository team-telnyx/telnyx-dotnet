using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailInboxes.Messages;
using Messages = Telnyx.Sdk.Services.EmailInboxes.Messages;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Messages::IActionService Actions { get; }

    Messages::ILabelService Labels { get; }

    /// <summary>
/// Updates the explicit read state of an account-scoped inbound message. Set
/// `read_at` to `true` to mark the message read at the server's current time, to an
/// ISO 8601 timestamp to use that timestamp, or to `null` to mark the message
/// unread. Repeating the same update is idempotent.
/// </summary>
    Task<MessageUpdateResponse> Update(
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessageUpdateParams, CancellationToken)"/>
    Task<MessageUpdateResponse> Update(
        string messageID,
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists inbound messages newest first. All access is scoped to the authenticated
/// account. `filter[search]` performs PostgreSQL full-text search over the subject,
/// plain-text body, and HTML body. Filters compose with stable cursor pagination.
/// </summary>
    Task<MessageListPage> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<MessageListPage> List(
        string inboxID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates an unsent reply draft for an inbound message. Unlike the
/// `/actions/reply` endpoint, which sends immediately, this stores a draft that can
/// be reviewed and edited before sending.
/// 
/// <para>`reply_to_message_id` and `thread_id` are inherited from the parent
/// message and cannot be set by the caller. The recipient, `Re:` subject and
/// `In-Reply-To`/`References` headers are pre-filled from the parent using the same
/// rules as a live reply, so sending the draft threads identically. Supplying `to`
/// or `subject` explicitly overrides the pre-filled value. </para>
/// </summary>
    Task<EmailDraftResponse> Drafts(
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Drafts(MessageDraftsParams, CancellationToken)"/>
    Task<EmailDraftResponse> Drafts(
        string messageID,
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Messages::IActionServiceWithRawResponse Actions { get; }

    Messages::ILabelServiceWithRawResponse Labels { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_inboxes/{inbox_id}/messages/{message_id}</c>, but is otherwise the
/// same as <see cref="IMessageService.Update(MessageUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageUpdateResponse>> Update(
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessageUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MessageUpdateResponse>> Update(
        string messageID,
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/messages</c>, but is otherwise the
/// same as <see cref="IMessageService.List(MessageListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageListPage>> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<HttpResponse<MessageListPage>> List(
        string inboxID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/messages/{message_id}/drafts</c>, but is otherwise the
/// same as <see cref="IMessageService.Drafts(MessageDraftsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDraftResponse>> Drafts(
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Drafts(MessageDraftsParams, CancellationToken)"/>
    Task<HttpResponse<EmailDraftResponse>> Drafts(
        string messageID,
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}