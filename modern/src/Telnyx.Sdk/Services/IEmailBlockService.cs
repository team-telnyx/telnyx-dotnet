using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailBlocks;
using Telnyx.Sdk.Services.EmailBlocks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Recipient suppression records (`/v2/email_blocks`).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailBlockService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailBlockServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailBlockService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IImportService Imports { get; }

    /// <summary>
/// Creates a suppression with `reason: manual_block` and `source: manual`.
/// Caller-supplied `reason` / `source` are **ignored**; `scope` is **derived**
/// server-side from `domain_id` / `from` and is never trusted. Idempotent: if a
/// matching row already exists (NULL-safe dedupe key: account_id, scope, to,
/// reason, domain_id, from), returns the existing record with `200` (no new audit
/// event).
/// 
/// <para>`bounce_category`, `dsn_code`, `meta`, and `group_id` are **not accepted**
/// on the public surface. Use the unsubscribe-group suppression endpoint or the
/// internal create surface for those. </para>
/// </summary>
    Task<EmailBlockResponse> Create(
        EmailBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the account-owned suppression identified by ID. Cross-account lookups
/// and malformed IDs return `404` without exposing another account’s data.
/// </summary>
    Task<EmailBlockResponse> Retrieve(
        EmailBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailBlockRetrieveParams, CancellationToken)"/>
    Task<EmailBlockResponse> Retrieve(
        string id,
        EmailBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Account-scoped list. Two mutually exclusive pagination modes:
/// 
/// <para>  - **Offset**: `page[number]` (default 1) + `page[size]`     (default 25,
/// max 100). `meta` contains `total_pages`.   - **Cursor**: `page[after]` and/or
/// `page[before]` (opaque     `Base.url_encode64` of `{"created_at","id"}`). Cannot
/// combine     with `page[number]`; `after`+`before` together is an error.
/// `meta` contains `next_cursor` / `previous_cursor` (omitted when     their flag
/// is false).</para>
/// 
/// <para>Sort defaults to `-created_at` (desc); only `created_at` is sortable. A
/// `--` prefix is an error. `nil`/empty filter values are silently dropped. </para>
/// </summary>
    Task<EmailBlockListPage> List(
        EmailBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Soft-deletes (status → `removed`; tombstone retained). A `removed` audit event
/// is appended unless the block was already `removed` (idempotent — returns the
/// existing row with `200` and no new event). Mutates `updated_at`.
/// </summary>
    Task<EmailBlockResponse> Delete(
        EmailBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailBlockDeleteParams, CancellationToken)"/>
    Task<EmailBlockResponse> Delete(
        string id,
        EmailBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Offset pagination only (`page[number]` default 1, `page[size]` default **50**,
/// max 100). No `sort`, no `filter`, no cursor — ordering is fixed `desc
/// occurred_at, desc id`. Verifies the block belongs to the account first
/// (cross-account → 404).
/// </summary>
    Task<EmailBlockRetrieveEventsPage> RetrieveEvents(
        EmailBlockRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(EmailBlockRetrieveEventsParams, CancellationToken)"/>
    Task<EmailBlockRetrieveEventsPage> RetrieveEvents(
        string id,
        EmailBlockRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Streams the account's suppressions as a chunked CSV (server-side cursor; never
/// materialized). Content-type `text/csv`, header `Content-Disposition: attachment;
/// filename="email_blocks_export.csv"`.
/// 
/// <para>Filters (`filter[reason]`, `filter[domain_id]`, `filter[created_after]`,
/// `filter[created_before]`) are the only params that affect output. `sort` and
/// `page[*]` are **parsed** (bad values still produce `400`) but **ignored** — rows
/// stream `ORDER BY created_at ASC, id ASC` with no pagination.</para>
/// 
/// <para>CSV columns: `id,to,from,reason,source,scope,status,domain_id,
/// created_at,updated_at,expires_at,group_id,bounce_category,dsn_code, meta` (15
/// columns). The first 12 columns are the stable native signature;
/// `bounce_category`, `dsn_code`, and `meta` are optional backup fields (empty when
/// unset). The CSV carries the `group_id` column so group-scoped suppressions'
/// group link survives the export (empty for account-scope rows). </para>
/// </summary>
    Task<string> RetrieveExport(
        EmailBlockRetrieveExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailBlockService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailBlockServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IImportServiceWithRawResponse Imports { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_blocks</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.Create(EmailBlockCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockResponse>> Create(
        EmailBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_blocks/{id}</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.Retrieve(EmailBlockRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockResponse>> Retrieve(
        EmailBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailBlockRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailBlockResponse>> Retrieve(
        string id,
        EmailBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_blocks</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.List(EmailBlockListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockListPage>> List(
        EmailBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_blocks/{id}</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.Delete(EmailBlockDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockResponse>> Delete(
        EmailBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailBlockDeleteParams, CancellationToken)"/>
    Task<HttpResponse<EmailBlockResponse>> Delete(
        string id,
        EmailBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_blocks/{id}/events</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.RetrieveEvents(EmailBlockRetrieveEventsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockRetrieveEventsPage>> RetrieveEvents(
        EmailBlockRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(EmailBlockRetrieveEventsParams, CancellationToken)"/>
    Task<HttpResponse<EmailBlockRetrieveEventsPage>> RetrieveEvents(
        string id,
        EmailBlockRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_blocks/export</c>, but is otherwise the
/// same as <see cref="IEmailBlockService.RetrieveExport(EmailBlockRetrieveExportParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> RetrieveExport(
        EmailBlockRetrieveExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}