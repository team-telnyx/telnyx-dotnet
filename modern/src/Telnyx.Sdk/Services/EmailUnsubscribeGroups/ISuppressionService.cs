using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailBlocks;
using Telnyx.Sdk.Models.EmailUnsubscribeGroups.Suppressions;

namespace Telnyx.Sdk.Services.EmailUnsubscribeGroups;

/// <summary>
/// Named groups and group-scoped suppressions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISuppressionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISuppressionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISuppressionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a suppression with `reason: unsubscribe`, `source: manual`, `group_id:
/// &lt;this group&gt;`. All other body fields are ignored; only `to` is read.
/// Idempotent (same dedupe key → `200`, no new event).
/// </summary>
    Task<EmailBlockResponse> Create(
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SuppressionCreateParams, CancellationToken)"/>
    Task<EmailBlockResponse> Create(
        string id,
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Account + group scoped. Offset pagination only (`page[number]` default 1,
/// `page[size]` default 25, max 100). No `sort`/`filter`/ cursor — ordering fixed
/// `desc created_at, desc id`. Uses the shared `QueryParser.parse_offset/1` — a
/// malformed `page` returns `400` (code `10015`), consistent with `GET
/// /v2/email_blocks`. `meta` includes `total_pages`. Rows reuse the standard
/// suppression shape (`group_id` set to this group).
/// </summary>
    Task<SuppressionListPage> List(
        SuppressionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SuppressionListParams, CancellationToken)"/>
    Task<SuppressionListPage> List(
        string id,
        SuppressionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Soft-deletes all active blocks for (account, group, normalized email) — one
/// `removed` audit event per block (`actor: manual`). The `email` path segment is
/// normalized (trim + lower-case) before matching. Idempotent on already-removed
/// rows (returns `404` since they're no longer `active`).
/// 
/// <para>Two distinct `404` cases: a missing/cross-account **group** returns `10001
/// "The requested unsubscribe group was not found"`; a group that exists but has
/// **no active suppression** for that email returns `10001 "The requested group
/// suppression was not found"`. </para>
/// </summary>
    Task Delete(
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SuppressionDeleteParams, CancellationToken)"/>
    Task Delete(
        string email,
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISuppressionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISuppressionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISuppressionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_unsubscribe_groups/{id}/suppressions</c>, but is otherwise the
/// same as <see cref="ISuppressionService.Create(SuppressionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockResponse>> Create(
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SuppressionCreateParams, CancellationToken)"/>
    Task<HttpResponse<EmailBlockResponse>> Create(
        string id,
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_unsubscribe_groups/{id}/suppressions</c>, but is otherwise the
/// same as <see cref="ISuppressionService.List(SuppressionListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SuppressionListPage>> List(
        SuppressionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SuppressionListParams, CancellationToken)"/>
    Task<HttpResponse<SuppressionListPage>> List(
        string id,
        SuppressionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_unsubscribe_groups/{id}/suppressions/{email}</c>, but is otherwise the
/// same as <see cref="ISuppressionService.Delete(SuppressionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SuppressionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string email,
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}