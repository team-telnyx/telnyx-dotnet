using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir;
using Dir = Telnyx.Sdk.Services.Dir;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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

    Dir::ICommentService Comments { get; }

    Dir::IPhoneNumberBatchService PhoneNumberBatches { get; }

    Dir::IPhoneNumberService PhoneNumbers { get; }

    Dir::IReferenceService References { get; }

    Dir::IVerifyEmailService VerifyEmail { get; }

    /// <summary>
/// Returns a single DIR by id. The enterprise is resolved server-side from the DIR
/// id. Returns `404` if the DIR does not exist or is not yours.
/// </summary>
    Task<DirWrapped> Retrieve(
        DirRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DirRetrieveParams, CancellationToken)"/>
    Task<DirWrapped> Retrieve(
        string dirID,
        DirRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Edit a DIR. DIRs in `draft`, `rejected`, `unsuccessful`, or `suspended` can be
/// edited freely: PATCH is a pure edit, `status` is never changed, and you re-vet
/// by calling `POST /v2/dir/{dir_id}/submit` explicitly. A `verified` DIR can also
/// be edited in place: a PATCH that changes any value returns the DIR to `draft`
/// and branded delivery stops until you re-submit and the DIR is approved again,
/// while a PATCH that changes nothing (an empty body or values identical to the
/// current ones) leaves the DIR `verified`, so idempotent retries are safe. DIRs in
/// any other status (`submitted`, `in_review`, `expired`, `infringement_claimed`,
/// `permanently_rejected`) cannot be edited.
/// </summary>
    Task<DirWrapped> Update(
        DirUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DirUpdateParams, CancellationToken)"/>
    Task<DirWrapped> Update(
        string dirID,
        DirUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns every DIR (Display Identity Record) you own, across all of your
/// enterprises, as a single list. Pagination is JSON:API style (`page[number]`,
/// `page[size]`, max 250). Supports `filter[]` query params:
/// `filter[enterprise_id]`, `filter[status]`, `filter[display_name][contains]`,
/// `filter[call_reason][contains]`, plus the renewal-window filters
/// `filter[expiring_at][gte]` / `filter[expiring_at][lte]`. Sortable by
/// `created_at`, `updated_at`, `display_name`, `status` (prefix `-` for descending;
/// default `-created_at`).
/// </summary>
    Task<DirListPage> List(
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a DIR. Failure modes: `400` if a child phone number is in a non-deletable
/// status, `409` if the DIR has an unresolved infringement claim, `404` if the DIR
/// is not yours.
/// </summary>
    Task Delete(
        DirDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DirDeleteParams, CancellationToken)"/>
    Task Delete(
        string dirID,
        DirDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Reference list of `document_type` values accepted by
/// `DirCreateRequest.documents[].document_type` and the infringement-contest
/// endpoint. Each entry has a stable `short_name` (used in API calls) and a
/// customer-facing description.
/// </summary>
    Task<DirListDocumentTypesResponse> ListDocumentTypes(
        DirListDocumentTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the trademark or copyright claims filed against this DIR. Each claim's
/// `status` is `pending` (newly filed; DIR auto-suspended), `contested` (you have
/// submitted contest evidence; awaiting resolution), or `resolved` (final).
/// Resolution outcomes: `upheld` (claim accepted; DIR stays
/// suspended/permanently_rejected), `rejected` (claim dismissed; DIR restored to
/// `verified`), `modified` (partial outcome).
/// </summary>
    Task<DirListInfringementClaimsPage> ListInfringementClaims(
        DirListInfringementClaimsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListInfringementClaims(DirListInfringementClaimsParams, CancellationToken)"/>
    Task<DirListInfringementClaimsPage> ListInfringementClaims(
        string dirID,
        DirListInfringementClaimsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Generate a pre-filled Letter of Authorization (LOA) PDF for a DIR. Enterprise
/// identity (legal name, DBA, address, contact, website, tax id) and the DIR
/// display name are read server-side; the caller supplies the telephone numbers to
/// authorize, an optional Authorized Agent block, and an optional drawn signature.
/// 
/// <para>When `signature` is omitted the PDF is returned unsigned so the customer
/// can sign it externally and upload it via the Documents API. When `signature` is
/// present the PDF embeds the supplied image, printed name, and signed-at date.</para>
/// 
/// <para>Returns `application/pdf`.</para>
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> NewLoa(
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="NewLoa(DirNewLoaParams, CancellationToken)"/>
    Task<HttpResponse> NewLoa(
        string dirID,
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submit a DIR for vetting. Sends the DIR back through the vetting cycle from any
/// non-terminal status. When re-submitting from `suspended` or `expired`, the DIR's
/// previous Branded Calling registration is torn down transactionally and its phone
/// numbers flip back to `submitted`. When re-submitting from `verified`, the
/// existing registration stays live throughout the new vetting cycle.
/// 
/// <para>Returns `400` from `submitted`/`in_review`/`permanently_rejected`. Returns
/// `400` if the DIR's business and financial references have not been submitted.
/// Returns `409` if the DIR has an unresolved infringement claim.</para>
/// </summary>
    Task<DirWrapped> Submit(
        DirSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(DirSubmitParams, CancellationToken)"/>
    Task<DirWrapped> Submit(
        string dirID,
        DirSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Push a fix for a DIR that is `suspended` with an open infringement claim back
/// into vetting. `POST /dir/{dir_id}/submit` is blocked while a claim is open, so
/// this is the customer-callable path to update the DIR's content and re-certify
/// before Telnyx adjudicates the claim. All four certification booleans must be
/// `true`. Optional content fields (`display_name`, `logo_url`, `call_reasons`,
/// `documents`) update the DIR; documents are append-only.
/// </summary>
    Task<DirWrapped> UpdateInfringement(
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateInfringement(DirUpdateInfringementParams, CancellationToken)"/>
    Task<DirWrapped> UpdateInfringement(
        string dirID,
        DirUpdateInfringementParams parameters,
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

    Dir::ICommentServiceWithRawResponse Comments { get; }

    Dir::IPhoneNumberBatchServiceWithRawResponse PhoneNumberBatches { get; }

    Dir::IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    Dir::IReferenceServiceWithRawResponse References { get; }

    Dir::IVerifyEmailServiceWithRawResponse VerifyEmail { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}</c>, but is otherwise the
/// same as <see cref="IDirService.Retrieve(DirRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirWrapped>> Retrieve(
        DirRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DirRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DirWrapped>> Retrieve(
        string dirID,
        DirRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /dir/{dir_id}</c>, but is otherwise the
/// same as <see cref="IDirService.Update(DirUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirWrapped>> Update(
        DirUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DirUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DirWrapped>> Update(
        string dirID,
        DirUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir</c>, but is otherwise the
/// same as <see cref="IDirService.List(DirListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirListPage>> List(
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /dir/{dir_id}</c>, but is otherwise the
/// same as <see cref="IDirService.Delete(DirDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        DirDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DirDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string dirID,
        DirDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/document_types</c>, but is otherwise the
/// same as <see cref="IDirService.ListDocumentTypes(DirListDocumentTypesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirListDocumentTypesResponse>> ListDocumentTypes(
        DirListDocumentTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/infringement_claims</c>, but is otherwise the
/// same as <see cref="IDirService.ListInfringementClaims(DirListInfringementClaimsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirListInfringementClaimsPage>> ListInfringementClaims(
        DirListInfringementClaimsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListInfringementClaims(DirListInfringementClaimsParams, CancellationToken)"/>
    Task<HttpResponse<DirListInfringementClaimsPage>> ListInfringementClaims(
        string dirID,
        DirListInfringementClaimsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/loa</c>, but is otherwise the
/// same as <see cref="IDirService.NewLoa(DirNewLoaParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> NewLoa(
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="NewLoa(DirNewLoaParams, CancellationToken)"/>
    Task<HttpResponse> NewLoa(
        string dirID,
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/submit</c>, but is otherwise the
/// same as <see cref="IDirService.Submit(DirSubmitParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirWrapped>> Submit(
        DirSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(DirSubmitParams, CancellationToken)"/>
    Task<HttpResponse<DirWrapped>> Submit(
        string dirID,
        DirSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /dir/{dir_id}/infringement_update</c>, but is otherwise the
/// same as <see cref="IDirService.UpdateInfringement(DirUpdateInfringementParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DirWrapped>> UpdateInfringement(
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateInfringement(DirUpdateInfringementParams, CancellationToken)"/>
    Task<HttpResponse<DirWrapped>> UpdateInfringement(
        string dirID,
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}