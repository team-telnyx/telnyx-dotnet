using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailMessages;
using Telnyx.Sdk.Services.EmailMessages;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Send and manage email messages. Legacy `/v2/emails` routes are aliases for these endpoints.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IRecipientService Recipients { get; }

    /// <summary>
/// Queues, schedules, or sandbox-sends an email message. The legacy `/v2/emails`
/// POST route is a backward-compatible alias for this operation.
/// 
/// <para>`subject` is required unless `template_id` is supplied. When using
/// `template_id`, do not also provide `subject`, `html_body`, or `text_body`; the
/// template is rendered with `template_variables`.</para>
/// 
/// <para>Note: template lookup failures (not found, wrong account) return 400, not
/// 404.</para>
/// </summary>
    Task<EmailMessageResponse> Create(
        EmailMessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// The legacy `/v2/emails/{id}` GET route is a backward-compatible alias for this
/// operation.
/// </summary>
    Task<EmailMessageDetailResponse> Retrieve(
        EmailMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailMessageRetrieveParams, CancellationToken)"/>
    Task<EmailMessageDetailResponse> Retrieve(
        string id,
        EmailMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists messages sorted newest first by `created_at desc, id desc`. Tags and
/// metadata filters compose with cursor pagination. The legacy `/v2/emails` GET
/// route is a backward-compatible alias for this operation.
/// </summary>
    Task<EmailMessageListPage> List(
        EmailMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes an account-scoped email message, its events, its durable
/// recipients, and unshared attachment objects. Returns 404 when the message does
/// not exist in the authenticated account. The legacy `/v2/emails/{id}` DELETE
/// route is a backward-compatible alias.
/// </summary>
    Task Delete(
        EmailMessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailMessageDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EmailMessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates up to 1,000 email messages in a single request. Request-wide admission
/// checks run first and can reject the whole batch before message creation. After
/// those checks pass, each message is validated and sent independently; item-level
/// failures do not affect other messages, and the processed batch returns 207
/// Multi-Status. Per-message failures include validation errors; when a template
/// has `strict_variables` enabled, a missing required variable produces a per-item
/// `unprocessable_entity` error naming that variable while the other messages
/// continue.
/// </summary>
    Task<EmailMessageBatchResponse> Batch(
        EmailMessageBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes every email in the authenticated account sent from or to the
/// supplied address, including retained events whose parent message has expired.
/// Events and durable recipients are deleted immediately with each message. The
/// operation never searches or reports matches in another account. The legacy
/// `/v2/emails` DELETE route is a backward-compatible alias.
/// </summary>
    Task DeleteAll(
        EmailMessageDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Cancels a scheduled email and returns it with status `cancelled`. The legacy
/// `/v2/emails/{id}/schedule` DELETE route is an alias.
/// </summary>
    Task<EmailMessageResponse> DeleteSchedule(
        EmailMessageDeleteScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteSchedule(EmailMessageDeleteScheduleParams, CancellationToken)"/>
    Task<EmailMessageResponse> DeleteSchedule(
        string emailID,
        EmailMessageDeleteScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists events for a single message sorted oldest first by `occurred_at asc, id
/// asc`. The legacy `/v2/emails/{id}/events` GET route is a backward-compatible
/// alias.
/// 
/// <para>For compatibility, each event carries the legacy customer-visible
/// `event_type` (`email.`-prefixed), the additive `canonical_event_type`
/// (`email.`-prefixed), and the deprecated `type` duplicate — whose value keeps the
/// exact legacy format: the bare stored event name, never `email.`-prefixed.
/// Gateway rejections render `email.failed` + canonical `email.gw_reject`; MTA
/// expirations render `email.bounced` + canonical `email.expired`; every unchanged
/// outcome carries identical `event_type` and `canonical_event_type` values (and
/// `type` keeps the stored name). </para>
/// </summary>
    Task<EmailMessageRetrieveEventsPage> RetrieveEvents(
        EmailMessageRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(EmailMessageRetrieveEventsParams, CancellationToken)"/>
    Task<EmailMessageRetrieveEventsPage> RetrieveEvents(
        string emailID,
        EmailMessageRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Moves an existing scheduled email to a new future send time. Only the delivery
/// time (`scheduled_at`) changes; the message ID, content, recipients, tags, and
/// metadata remain unchanged. Returns `409 Conflict` if the message is no longer
/// scheduled or its scheduled-send worker has already started processing it. This
/// route emits no dedicated `rescheduled` event.
/// </summary>
    Task<EmailMessageDetailResponse> UpdateSchedule(
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateSchedule(EmailMessageUpdateScheduleParams, CancellationToken)"/>
    Task<EmailMessageDetailResponse> UpdateSchedule(
        string emailID,
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IRecipientServiceWithRawResponse Recipients { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_messages</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.Create(EmailMessageCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> Create(
        EmailMessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_messages/{id}</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.Retrieve(EmailMessageRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageDetailResponse>> Retrieve(
        EmailMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailMessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageDetailResponse>> Retrieve(
        string id,
        EmailMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_messages</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.List(EmailMessageListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageListPage>> List(
        EmailMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_messages/{id}</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.Delete(EmailMessageDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        EmailMessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailMessageDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EmailMessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_messages/batch</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.Batch(EmailMessageBatchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageBatchResponse>> Batch(
        EmailMessageBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_messages</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.DeleteAll(EmailMessageDeleteAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteAll(
        EmailMessageDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_messages/{email_id}/schedule</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.DeleteSchedule(EmailMessageDeleteScheduleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> DeleteSchedule(
        EmailMessageDeleteScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteSchedule(EmailMessageDeleteScheduleParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageResponse>> DeleteSchedule(
        string emailID,
        EmailMessageDeleteScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_messages/{email_id}/events</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.RetrieveEvents(EmailMessageRetrieveEventsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageRetrieveEventsPage>> RetrieveEvents(
        EmailMessageRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(EmailMessageRetrieveEventsParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageRetrieveEventsPage>> RetrieveEvents(
        string emailID,
        EmailMessageRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_messages/{email_id}/schedule</c>, but is otherwise the
/// same as <see cref="IEmailMessageService.UpdateSchedule(EmailMessageUpdateScheduleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageDetailResponse>> UpdateSchedule(
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateSchedule(EmailMessageUpdateScheduleParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageDetailResponse>> UpdateSchedule(
        string emailID,
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}