using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;
using Telnyx.Sdk.Models.TermsOfService.NumberReputation;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <summary>
/// Accept and review the Branded Calling and Phone Number Reputation terms of service.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberReputationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberReputationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberReputationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Records the authenticated user's agreement to the current Phone Number
/// Reputation ToS. No body required. Idempotent.
/// 
/// <para>Prerequisite for using any of the `/v2/.../reputation/*` endpoints.</para>
/// </summary>
    Task<TosAgreementWrapped> Agree(
        NumberReputationAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberReputationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberReputationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberReputationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /terms_of_service/number_reputation/agree</c>, but is otherwise the
/// same as <see cref="INumberReputationService.Agree(NumberReputationAgreeParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TosAgreementWrapped>> Agree(
        NumberReputationAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}