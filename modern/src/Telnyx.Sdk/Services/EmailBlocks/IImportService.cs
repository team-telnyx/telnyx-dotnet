using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailBlocks.Imports;

namespace Telnyx.Sdk.Services.EmailBlocks;

/// <summary>
/// Async CSV import of competitor suppression lists.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IImportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Accepts `multipart/form-data` with a `file` field (the CSV) and an optional
/// `block_ttl_days` (integer &gt;0, default 30). Validates:   - content ≤ 25 MiB,
/// else `413`   - row count ≤ 250 000, else `413`   - header-only / all-blank /
/// undetectable provider → `400` Returns `202` with the import record (status
/// `pending`); an Oban worker (`EmailBlockImportWorker`, max_attempts 3)
/// transitions `pending → processing → completed | failed`.
/// 
/// <para>Native Telnyx exports are detected by the stable first-12-column header
/// signature (`id` … `group_id`) and are restored with their original `from`,
/// `domain_id`, `group_id`, `source`, `status`, `expires_at`, plus
/// `bounce_category`, `dsn_code`, and `meta` when present (`scope` is re-derived
/// from `domain_id`/`from`; the exported `scope` cell must be a valid enum value).
/// Lifecycle changes reconcile through the same create path as the API: a row
/// already in the requested state restores its mutable backup fields without a new
/// audit event, and a real transition (e.g. tombstone → active) appends the
/// matching lifecycle event. `block_ttl_days` is not applied to native rows — their
/// exported `expires_at` is preserved verbatim.</para>
/// 
/// <para>Competitor and generic imports (SendGrid / Mailgun / SES / generic) remain
/// account-scoped (`from`, `domain_id`, `group_id`, `scope` are not read) and
/// `block_ttl_days` applies only to imported `manual_block` rows; other reasons get
/// `expires_at: nil`. Provider is auto-detected from the CSV header (`sendgrid` /
/// `mailgun` / `ses` / `generic`). </para>
/// </summary>
    Task<EmailBlockImportResponse> Create(
        ImportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Account-scoped fetch (cross-account → 404; malformed UUID → 404). Nullable
/// fields are omitted until terminal: `provider`/`completed_at` when nil;
/// `processed_rows`/`created_count`/`existing_count`/ `skipped_count`/`error_count`
/// only when `status == completed`; `errors` only when non-empty; `failure_reason`
/// only on terminal failure.
/// </summary>
    Task<EmailBlockImportResponse> Retrieve(
        ImportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ImportRetrieveParams, CancellationToken)"/>
    Task<EmailBlockImportResponse> Retrieve(
        string id,
        ImportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IImportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IImportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_blocks/import</c>, but is otherwise the
/// same as <see cref="IImportService.Create(ImportCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockImportResponse>> Create(
        ImportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_blocks/import/{id}</c>, but is otherwise the
/// same as <see cref="IImportService.Retrieve(ImportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailBlockImportResponse>> Retrieve(
        ImportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ImportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailBlockImportResponse>> Retrieve(
        string id,
        ImportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}