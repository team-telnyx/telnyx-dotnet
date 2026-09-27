using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.References;

namespace Telnyx.Sdk.Services.Dir;

/// <summary>
/// Submit and manage the two business references and one financial reference that
/// vouch for a DIR. References are contacted to confirm the business identity during vetting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Submit the two business references and one financial reference for a DIR.
/// 
/// <para>The DIR's authorizer email must be verified first (see the
/// email-verification endpoint). Until it is, this returns `409` and no references
/// are stored.</para>
/// 
/// <para>The request body carries exactly two business references plus one
/// financial reference. The first submission stores them and returns `201`.
/// Resubmitting returns `200`: identical values are simply confirmed and nothing is
/// written, while changed values replace those references.</para>
/// 
/// <para>Replacing a reference is allowed only while the DIR itself is still
/// editable, the same window in which a single reference may be updated; once the
/// DIR has been submitted for vetting this returns `400`. A replaced reference's
/// pending verification call is cancelled and its dial-in code stops working, and
/// the replacement contact is emailed fresh scheduling details. References whose
/// details did not change keep their existing call, code, and the notice already
/// sent to them.</para>
/// 
/// <para>The response always echoes the stored references in the same shape as the
/// GET.</para>
/// 
/// <para>Who qualifies: the two business references confirm the company's
/// reputation and operations. Each should be a senior contact at an organization
/// the business works with, such as a vendor, partner, or client: a C-suite
/// executive (CEO, CFO, CTO, COO), an owner or founder as reflected in the
/// company's corporate records, or a senior manager, director, or executive. The
/// financial reference confirms the company pays its bills and should be a licensed
/// certified public accountant (CPA) the company uses, a contact at a bank or
/// financial institution that has a relationship with the company, or a reasonable
/// alternative banking or financial reference.</para>
/// </summary>
    Task<ReferenceList> Create(
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ReferenceCreateParams, CancellationToken)"/>
    Task<ReferenceList> Create(
        string dirID,
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Partially update one reference, addressed by the DIR id plus the reference's
/// type (business or financial) and slot.
/// 
/// <para>Cosmetic fields (full name, job title, organization, relationship, email)
/// are always editable. The phone number and timezone may only be changed while a
/// scheduled call has not yet been dialed; if a call is in progress or all attempts
/// are complete, those fields are locked. Changing the timezone reschedules any
/// pending call into the new local calling window.</para>
/// </summary>
    Task<ReferenceUpdateResponse> Update(
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ReferenceUpdateParams, CancellationToken)"/>
    Task<ReferenceUpdateResponse> Update(
        long slot,
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List the business and financial references submitted for a DIR.
/// 
/// <para>Returns the two business references (slots 1 and 2) followed by the single
/// financial reference. Each entry carries its `ref_type` and `slot`, which
/// together address the reference when updating it, alongside the details supplied
/// when it was submitted (name, title, organization, relationship, phone, email,
/// timezone). No internal identifiers are exposed. Returns an empty list when no
/// references were submitted.</para>
/// </summary>
    Task<ReferenceList> List(
        ReferenceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ReferenceListParams, CancellationToken)"/>
    Task<ReferenceList> List(
        string dirID,
        ReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IReferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/references</c>, but is otherwise the
/// same as <see cref="IReferenceService.Create(ReferenceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReferenceList>> Create(
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ReferenceCreateParams, CancellationToken)"/>
    Task<HttpResponse<ReferenceList>> Create(
        string dirID,
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /dir/{dir_id}/references/{ref_type}/{slot}</c>, but is otherwise the
/// same as <see cref="IReferenceService.Update(ReferenceUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReferenceUpdateResponse>> Update(
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ReferenceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ReferenceUpdateResponse>> Update(
        long slot,
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/references</c>, but is otherwise the
/// same as <see cref="IReferenceService.List(ReferenceListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReferenceList>> List(
        ReferenceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ReferenceListParams, CancellationToken)"/>
    Task<HttpResponse<ReferenceList>> List(
        string dirID,
        ReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}