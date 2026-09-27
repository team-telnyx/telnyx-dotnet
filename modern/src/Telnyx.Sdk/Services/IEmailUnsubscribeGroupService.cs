using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailUnsubscribeGroups;
using Telnyx.Sdk.Services.EmailUnsubscribeGroups;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Named groups and group-scoped suppressions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailUnsubscribeGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailUnsubscribeGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailUnsubscribeGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ISuppressionService Suppressions { get; }

    /// <summary>
/// Creates an account-owned unsubscribe group for associating email categories with
/// separate recipient suppression lists.
/// </summary>
    Task<UnsubscribeGroupResponse> Create(
        EmailUnsubscribeGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the account-owned unsubscribe group identified by ID.
/// </summary>
    Task<UnsubscribeGroupResponse> Retrieve(
        EmailUnsubscribeGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailUnsubscribeGroupRetrieveParams, CancellationToken)"/>
    Task<UnsubscribeGroupResponse> Retrieve(
        string id,
        EmailUnsubscribeGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Partial update (only `name` / `description`). `PUT` is not routed.
/// </summary>
    Task<UnsubscribeGroupResponse> Update(
        EmailUnsubscribeGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailUnsubscribeGroupUpdateParams, CancellationToken)"/>
    Task<UnsubscribeGroupResponse> Update(
        string id,
        EmailUnsubscribeGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Offset pagination only (`page[number]` default 1, `page[size]` default 25, max
/// 100). No `sort`/`filter`/cursor — ordering fixed `desc created_at, desc id`.
/// Uses the shared `QueryParser.parse_offset/1` — a malformed `page` (e.g. flat
/// `?page=1` instead of `?page[number]=1`) returns `400` (code `10015`), consistent
/// with `GET /v2/email_blocks`. `meta` includes `total_pages`.
/// </summary>
    Task<EmailUnsubscribeGroupListPage> List(
        EmailUnsubscribeGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// If the group has 0 active suppressions, hard-deletes the row. With `force=true`,
/// soft-deletes all active suppressions first (status → `removed`, `group_id`
/// cleared, `removed` audit event per block) in a single transaction, then
/// hard-deletes the group. Without `force` and active suppressions present → `409`.
/// Audit trail is preserved. `force` only accepts the string `"true"` or boolean
/// `true`; all other values are false.
/// </summary>
    Task Delete(
        EmailUnsubscribeGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailUnsubscribeGroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EmailUnsubscribeGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailUnsubscribeGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailUnsubscribeGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailUnsubscribeGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ISuppressionServiceWithRawResponse Suppressions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_unsubscribe_groups</c>, but is otherwise the
/// same as <see cref="IEmailUnsubscribeGroupService.Create(EmailUnsubscribeGroupCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UnsubscribeGroupResponse>> Create(
        EmailUnsubscribeGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_unsubscribe_groups/{id}</c>, but is otherwise the
/// same as <see cref="IEmailUnsubscribeGroupService.Retrieve(EmailUnsubscribeGroupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UnsubscribeGroupResponse>> Retrieve(
        EmailUnsubscribeGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailUnsubscribeGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UnsubscribeGroupResponse>> Retrieve(
        string id,
        EmailUnsubscribeGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_unsubscribe_groups/{id}</c>, but is otherwise the
/// same as <see cref="IEmailUnsubscribeGroupService.Update(EmailUnsubscribeGroupUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UnsubscribeGroupResponse>> Update(
        EmailUnsubscribeGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailUnsubscribeGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UnsubscribeGroupResponse>> Update(
        string id,
        EmailUnsubscribeGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_unsubscribe_groups</c>, but is otherwise the
/// same as <see cref="IEmailUnsubscribeGroupService.List(EmailUnsubscribeGroupListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailUnsubscribeGroupListPage>> List(
        EmailUnsubscribeGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_unsubscribe_groups/{id}</c>, but is otherwise the
/// same as <see cref="IEmailUnsubscribeGroupService.Delete(EmailUnsubscribeGroupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        EmailUnsubscribeGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailUnsubscribeGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EmailUnsubscribeGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}