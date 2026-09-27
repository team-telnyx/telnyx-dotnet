using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailInboxes.Messages.Actions;

namespace Telnyx.Sdk.Services.EmailInboxes.Messages;

/// <summary>
/// Create and manage agent inboxes, retrieve inbound messages and threads, and reply
/// to or forward messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Sends from the inbox address through the standard email send pipeline to
/// caller-supplied To, Cc, and Bcc recipients. `to` must contain at least one
/// recipient. Optional `text` and `html` are prepended to a forwarded-message block
/// containing the original metadata and available body content. The subject is
/// prefixed with `Fwd:` unless it already has that prefix.
/// 
/// <para>Threading headers are derived from the original message: `In-Reply-To` is
/// set to its RFC Message-ID, and `References` contains the original References
/// values plus that Message-ID, de-duplicated and limited to the most recent 20
/// values. </para>
/// </summary>
    Task<EmailMessageResponse> Forward(
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Forward(ActionForwardParams, CancellationToken)"/>
    Task<EmailMessageResponse> Forward(
        string messageID,
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends from the inbox address through the standard email send pipeline. The
/// recipient is the original `Reply-To`, falling back to `From`; original Cc
/// recipients are not included. The subject is prefixed with `Re:` unless it
/// already has that prefix.
/// 
/// <para>Threading headers are derived from the original message: `In-Reply-To` is
/// set to its RFC Message-ID, and `References` contains the original References
/// values plus that Message-ID, de-duplicated and limited to the most recent 20
/// values. </para>
/// </summary>
    Task<EmailMessageResponse> Reply(
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Reply(ActionReplyParams, CancellationToken)"/>
    Task<EmailMessageResponse> Reply(
        string messageID,
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends from the inbox address through the standard email send pipeline. The To
/// list starts with the original `Reply-To` (or `From`) and includes original To
/// recipients; the Cc list includes original Cc recipients. The inbox address is
/// excluded, and recipients are de-duplicated case-insensitively across To and Cc.
/// Bcc is always empty. The subject is prefixed with `Re:` unless it already has
/// that prefix.
/// 
/// <para>Threading headers are derived from the original message: `In-Reply-To` is
/// set to its RFC Message-ID, and `References` contains the original References
/// values plus that Message-ID, de-duplicated and limited to the most recent 20
/// values. </para>
/// </summary>
    Task<EmailMessageResponse> ReplyAll(
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ReplyAll(ActionReplyAllParams, CancellationToken)"/>
    Task<EmailMessageResponse> ReplyAll(
        string messageID,
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/messages/{message_id}/actions/forward</c>, but is otherwise the
/// same as <see cref="IActionService.Forward(ActionForwardParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> Forward(
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Forward(ActionForwardParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageResponse>> Forward(
        string messageID,
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/messages/{message_id}/actions/reply</c>, but is otherwise the
/// same as <see cref="IActionService.Reply(ActionReplyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> Reply(
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Reply(ActionReplyParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageResponse>> Reply(
        string messageID,
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/messages/{message_id}/actions/reply_all</c>, but is otherwise the
/// same as <see cref="IActionService.ReplyAll(ActionReplyAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> ReplyAll(
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ReplyAll(ActionReplyAllParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageResponse>> ReplyAll(
        string messageID,
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}