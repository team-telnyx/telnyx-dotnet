using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <summary>
/// Create, list, retrieve, update, delete, and send unsent draft messages belonging
/// to an agent inbox.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDraftService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDraftServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates an unsent draft in the inbox. Every field is optional — a draft is a
/// work-in-progress and may be saved incomplete. Send-time requirements (sender,
/// subject, at least one recipient) are enforced when the draft is sent, not when
/// it is created.
/// 
/// <para>Drafts are unbillable and emit no Email Detail Records until they are
/// sent. </para>
/// </summary>
    Task<EmailDraftResponse> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DraftCreateParams, CancellationToken)"/>
    Task<EmailDraftResponse> Create(
        string inboxID,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a single draft. Drafts that have been sent remain retrievable, so the
/// exact content that was sent stays auditable.
/// </summary>
    Task<EmailDraftResponse> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DraftRetrieveParams, CancellationToken)"/>
    Task<EmailDraftResponse> Retrieve(
        string draftID,
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied fields on a draft. `account_id` and `inbox_id` are
/// server-owned and ignored if present in the body, so a draft can never be moved
/// between accounts or inboxes.
/// 
/// <para>A draft that is being sent or has already been sent is immutable and
/// returns 422 — modifying it would race with delivery or rewrite the record of
/// what was actually sent. </para>
/// </summary>
    Task<EmailDraftResponse> Update(
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DraftUpdateParams, CancellationToken)"/>
    Task<EmailDraftResponse> Update(
        string draftID,
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists drafts newest first using stable cursor pagination. All access is scoped
/// to the authenticated account and the given inbox.
/// </summary>
    Task<DraftListPage> List(
        DraftListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(DraftListParams, CancellationToken)"/>
    Task<DraftListPage> List(
        string inboxID,
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes an unsent draft. Drafts that are being sent or have been
/// sent cannot be deleted; sent drafts are retained for audit.
/// </summary>
    Task Delete(
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DraftDeleteParams, CancellationToken)"/>
    Task Delete(
        string draftID,
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Identical to `PUT`; both apply a partial update to the supplied fields.
/// </summary>
    Task<EmailDraftResponse> Patch(
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Patch(DraftPatchParams, CancellationToken)"/>
    Task<EmailDraftResponse> Patch(
        string draftID,
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends the draft through the standard send pipeline — the same domain resolution,
/// suppression, reputation, daily-quota, persistence and Detail Record behaviour as
/// `POST /v2/email_messages`. The response body is the created email message.
/// 
/// <para>If the draft has no explicit `from_email`, the inbox address is used.</para>
/// 
/// <para>The draft is marked `sent` only after the send is accepted; a send
/// rejected for suppression, quota or reputation leaves the draft editable so it
/// can be fixed and retried. A draft that is already `sent` returns 422 rather than
/// sending twice. </para>
/// </summary>
    Task<EmailMessageResponse> Send(
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Send(DraftSendParams, CancellationToken)"/>
    Task<EmailMessageResponse> Send(
        string draftID,
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDraftService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDraftServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/drafts</c>, but is otherwise the
/// same as <see cref="IDraftService.Create(DraftCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDraftResponse>> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DraftCreateParams, CancellationToken)"/>
    Task<HttpResponse<EmailDraftResponse>> Create(
        string inboxID,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/drafts/{draft_id}</c>, but is otherwise the
/// same as <see cref="IDraftService.Retrieve(DraftRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDraftResponse>> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DraftRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailDraftResponse>> Retrieve(
        string draftID,
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /email_inboxes/{inbox_id}/drafts/{draft_id}</c>, but is otherwise the
/// same as <see cref="IDraftService.Update(DraftUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDraftResponse>> Update(
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DraftUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EmailDraftResponse>> Update(
        string draftID,
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/drafts</c>, but is otherwise the
/// same as <see cref="IDraftService.List(DraftListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DraftListPage>> List(
        DraftListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(DraftListParams, CancellationToken)"/>
    Task<HttpResponse<DraftListPage>> List(
        string inboxID,
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_inboxes/{inbox_id}/drafts/{draft_id}</c>, but is otherwise the
/// same as <see cref="IDraftService.Delete(DraftDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DraftDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string draftID,
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_inboxes/{inbox_id}/drafts/{draft_id}</c>, but is otherwise the
/// same as <see cref="IDraftService.Patch(DraftPatchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDraftResponse>> Patch(
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Patch(DraftPatchParams, CancellationToken)"/>
    Task<HttpResponse<EmailDraftResponse>> Patch(
        string draftID,
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/drafts/{draft_id}/send</c>, but is otherwise the
/// same as <see cref="IDraftService.Send(DraftSendParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailMessageResponse>> Send(
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Send(DraftSendParams, CancellationToken)"/>
    Task<HttpResponse<EmailMessageResponse>> Send(
        string draftID,
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}