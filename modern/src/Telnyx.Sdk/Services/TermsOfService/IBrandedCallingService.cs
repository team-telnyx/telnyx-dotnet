using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;
using Telnyx.Sdk.Models.TermsOfService.BrandedCalling;

namespace Telnyx.Sdk.Services.TermsOfService;

/// <summary>
/// Accept and review the Branded Calling and Phone Number Reputation terms of service.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBrandedCallingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandedCallingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandedCallingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Records the authenticated user's agreement to the current Branded Calling ToS.
/// No body required. Idempotent - re-calling after agreement is a no-op and returns
/// the existing agreement.
/// 
/// <para>This is a prerequisite for activating Branded Calling on any enterprise
/// (`POST /enterprises/{id}/branded_calling`); without an agreement, activation
/// returns `403`.</para>
/// </summary>
    Task<TosAgreementWrapped> Agree(
        BrandedCallingAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBrandedCallingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandedCallingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandedCallingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /terms_of_service/branded_calling/agree</c>, but is otherwise the
/// same as <see cref="IBrandedCallingService.Agree(BrandedCallingAgreeParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TosAgreementWrapped>> Agree(
        BrandedCallingAgreeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}