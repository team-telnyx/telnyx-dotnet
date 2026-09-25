using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Dir = Telnyx.Sdk.Models.Dir;
using Telnyx.Sdk.Models.Enterprises.Dir;

namespace Telnyx.Sdk.Services.Enterprises;

/// <summary>
/// A Display Identity Record (DIR) is the verified calling identity (display name,
/// logo, call reasons) shown to recipients on outbound calls.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDirService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDirServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDirService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Create a new DIR under the given enterprise. The DIR starts in `draft` status;
/// it must be submitted (`POST .../submit`) and approved by Telnyx before any phone
/// number can be attached.
/// 
/// <para>**Field rules** - `display_name`: 1–35 characters, no emoji or
/// whitespace-only strings; this is the name shown to recipients. - `call_reasons`:
/// 1–10 strings, each ≤64 characters; describe why your business calls customers
/// (e.g. 'Appointment reminders', 'Billing inquiries'). Validate the wording
/// against `POST /call_reasons/validate`. - `logo_url`: HTTPS URL (max 128 chars)
/// to a 256×256 BMP (max 1 MB). The image is downloaded and hashed at submission
/// time. - `documents`: up to 20 entries; each `document_id` must be obtained by
/// uploading the file via the Telnyx Documents API first. Within one DIR a
/// `document_id` may only appear once. - `certify_brand_is_accurate`,
/// `certify_no_shaft_content`, `certify_ip_ownership` MUST all be `true`.</para>
/// 
/// <para>**Failure modes** - `422` - validation error; `errors[].source.pointer`
/// names the offending field. - `403` - Branded Calling not activated on this
/// enterprise (see `POST /enterprises/{id}/branded_calling`). - `404` - enterprise
/// does not exist or does not belong to your account.</para>
/// </summary>
    Task<Dir::DirWrapped> Create(
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DirCreateParams, CancellationToken)"/>
    Task<Dir::DirWrapped> Create(
        string enterpriseID,
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the DIRs (Display Identity Records) belonging to a single enterprise.
/// Pagination is JSON:API style (`page[number]`, `page[size]`, max 250). Supports
/// `filter[]` query params: `filter[status]`, `filter[display_name][contains]`,
/// `filter[call_reason][contains]`, plus the renewal-window filters
/// `filter[expiring_at][gte]` / `filter[expiring_at][lte]` and the convenience
/// `filter[expiring_within_days]` (mutually exclusive with the explicit gte/lte
/// form). Sortable by `created_at`, `updated_at`, `display_name`, `status`,
/// `submitted_at`, `verified_at`, `expiring_at` (prefix `-` for descending; default
/// `-created_at`).
/// </summary>
    Task<DirListPage> List(
        DirListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(DirListParams, CancellationToken)"/>
    Task<DirListPage> List(
        string enterpriseID,
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDirService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDirServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDirServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/dir</c>, but is otherwise the
/// same as <see cref="IDirService.Create(DirCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dir::DirWrapped>> Create(
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DirCreateParams, CancellationToken)"/>
    Task<HttpResponse<Dir::DirWrapped>> Create(
        string enterpriseID,
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/dir</c>, but is otherwise the
/// same as <see cref="IDirService.List(DirListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirListPage>> List(
        DirListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(DirListParams, CancellationToken)"/>
    Task<HttpResponse<DirListPage>> List(
        string enterpriseID,
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}