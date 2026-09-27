using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <summary>
/// Accept and review the Branded Calling and Phone Number Reputation terms of service.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAgreementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgreementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgreementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve a single ToS agreement record. Returns `404` if the agreement does not
/// exist or does not belong to the authenticated user.
/// </summary>
    Task<TosAgreementWrapped> Retrieve(
        AgreementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgreementRetrieveParams, CancellationToken)"/>
    Task<TosAgreementWrapped> Retrieve(
        string agreementID,
        AgreementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the Terms of Service agreements the authenticated user has on file. Each
/// entry records the version agreed to and when. Most users only have one agreement
/// per product, but if the ToS is updated and the user re-agrees a new entry is
/// added.
/// 
/// <para>Results are paginated with the standard `page[number]` / `page[size]`
/// parameters; the response uses the standard `{data, meta}` JSON:API envelope.</para>
/// 
/// <para>By default this returns agreements for **all** products the user has
/// agreed to. Pass the `product_type` query parameter to scope the result to a
/// single product.</para>
/// </summary>
    Task<AgreementListPage> List(
        AgreementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAgreementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgreementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgreementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /terms_of_service/agreements/{agreement_id}</c>, but is otherwise the
/// same as <see cref="IAgreementService.Retrieve(AgreementRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TosAgreementWrapped>> Retrieve(
        AgreementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgreementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TosAgreementWrapped>> Retrieve(
        string agreementID,
        AgreementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /terms_of_service/agreements</c>, but is otherwise the
/// same as <see cref="IAgreementService.List(AgreementListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgreementListPage>> List(
        AgreementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}