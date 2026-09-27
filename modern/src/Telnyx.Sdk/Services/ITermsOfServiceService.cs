using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService;
using Telnyx.Sdk.Services.TermsOfService;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Accept and review the Branded Calling and Phone Number Reputation terms of service.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITermsOfServiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITermsOfServiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITermsOfServiceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    INumberReputationService NumberReputation { get; }

    IAgreementService Agreements { get; }

    IBrandedCallingService BrandedCalling { get; }

    /// <summary>
/// Returns the available Terms of Service agreements (product, current version,
/// terms URL, effective date). Omit `product_type` to return all products; pass it
/// to scope to one.
/// </summary>
    Task<TermsOfServiceRetrieveInfoResponse> RetrieveInfo(
        TermsOfServiceRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns whether the authenticated user has agreed to the current Terms of
/// Service for the product given by `product_type`. Used during onboarding to
/// decide whether to prompt the user with the ToS dialog before continuing.
/// 
/// <para>`agreement_required: true` means the user has not yet agreed (or has
/// agreed to an outdated version) and must agree before using that product's
/// endpoints.</para>
/// </summary>
    Task<TermsOfServiceRetrieveStatusResponse> RetrieveStatus(
        TermsOfServiceRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITermsOfServiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITermsOfServiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITermsOfServiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    INumberReputationServiceWithRawResponse NumberReputation { get; }

    IAgreementServiceWithRawResponse Agreements { get; }

    IBrandedCallingServiceWithRawResponse BrandedCalling { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /terms_of_service/info</c>, but is otherwise the
/// same as <see cref="ITermsOfServiceService.RetrieveInfo(TermsOfServiceRetrieveInfoParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TermsOfServiceRetrieveInfoResponse>> RetrieveInfo(
        TermsOfServiceRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /terms_of_service/status</c>, but is otherwise the
/// same as <see cref="ITermsOfServiceService.RetrieveStatus(TermsOfServiceRetrieveStatusParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TermsOfServiceRetrieveStatusResponse>> RetrieveStatus(
        TermsOfServiceRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}