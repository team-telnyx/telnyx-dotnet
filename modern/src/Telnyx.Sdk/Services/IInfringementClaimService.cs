using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InfringementClaims;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Trademark or impersonation claims filed against your DIR. Customers may contest
/// a claim with supporting evidence.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInfringementClaimService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInfringementClaimServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInfringementClaimService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve a single claim by id. Returns `404` if the claim does not exist or is
/// not against a DIR you own.
/// </summary>
    Task<InfringementClaimWrapped> Retrieve(
        InfringementClaimRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InfringementClaimRetrieveParams, CancellationToken)"/>
    Task<InfringementClaimWrapped> Retrieve(
        string claimID,
        InfringementClaimRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submit a written response and supporting documents disputing the claim. The
/// first call moves the claim from `pending` to `contested`; subsequent calls
/// append supplementary evidence without changing status. The `documents[]` you
/// attach are aggregated across rounds in the claim's `contest_documents` field.
/// 
/// <para>Only `pending` and `contested` claims accept new evidence. A `resolved`
/// claim returns `400`.</para>
/// 
/// <para>Failure modes: - `400` - the claim is `resolved` (terminal); cannot be
/// contested further. - `404` - the claim does not exist or is not against a DIR
/// you own. - `422` - `contest_notes` is too short (&lt; 10 chars), too long (&gt;
/// 2000 chars), `documents` is &gt; 20 entries, or a `document_id` is duplicated
/// within the same submission.</para>
/// </summary>
    Task<InfringementClaimWrapped> Contest(
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Contest(InfringementClaimContestParams, CancellationToken)"/>
    Task<InfringementClaimWrapped> Contest(
        string claimID,
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInfringementClaimService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInfringementClaimServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInfringementClaimServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /infringement_claims/{claim_id}</c>, but is otherwise the
/// same as <see cref="IInfringementClaimService.Retrieve(InfringementClaimRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InfringementClaimWrapped>> Retrieve(
        InfringementClaimRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InfringementClaimRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InfringementClaimWrapped>> Retrieve(
        string claimID,
        InfringementClaimRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /infringement_claims/{claim_id}/contest</c>, but is otherwise the
/// same as <see cref="IInfringementClaimService.Contest(InfringementClaimContestParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InfringementClaimWrapped>> Contest(
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Contest(InfringementClaimContestParams, CancellationToken)"/>
    Task<HttpResponse<InfringementClaimWrapped>> Contest(
        string claimID,
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}