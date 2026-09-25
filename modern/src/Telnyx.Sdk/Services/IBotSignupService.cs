using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotSignup;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Agentic (bot) signup for Telnyx accounts. An AI agent solves a reverse-CAPTCHA
/// challenge designed to be easy for LLMs and hard for humans, registers an account,
/// and signs in by consuming a magic link emailed to the account owner. All endpoints
/// are public and unauthenticated; signup endpoints are additionally gated by the
/// freemium feature flags and per-country availability.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBotSignupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBotSignupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotSignupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a freemium Telnyx account through the agentic signup flow. The request
/// must carry a valid answer to a previously issued bot challenge
/// (`bot_challenge_nonce` and `bot_challenge_answer`), accept the terms of service,
/// and echo the exact terms-and-conditions and privacy-policy URLs returned by the
/// challenge endpoint. When EU consent enforcement is enabled,
/// `terms_of_service_eu` and `terms_and_conditions_eu_url` are also required. On
/// success a one-time sign-in (magic) link is emailed to the address provided; if
/// the email address belongs to an existing account, a sign-in link is sent instead
/// of creating a duplicate account. `email` may only be omitted when
/// placeholder-email registration is enabled server-side. This endpoint is public
/// and unauthenticated, gated by the freemium feature flags and per-country
/// availability, and subject to per-IP and per-domain registration limits.
/// </summary>
    Task<SuccessResponse> Create(
        BotSignupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Resends the one-time sign-in (magic) link for an eligible bot signup account.
/// Eligibility (account exists, was registered through bot signup, is active, and
/// has not exceeded the resend limit or rate window) is evaluated server-side; the
/// response is intentionally uniform and does not reveal whether the account exists
/// or whether a link was actually sent. This endpoint is public and
/// unauthenticated, gated by the freemium feature flags and per-country
/// availability.
/// </summary>
    Task<SuccessResponse> ResendMagicLink(
        BotSignupResendMagicLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBotSignupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBotSignupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotSignupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/bot_signup</c>, but is otherwise the
/// same as <see cref="IBotSignupService.Create(BotSignupCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SuccessResponse>> Create(
        BotSignupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/bot_signup/resend_magic_link</c>, but is otherwise the
/// same as <see cref="IBotSignupService.ResendMagicLink(BotSignupResendMagicLinkParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SuccessResponse>> ResendMagicLink(
        BotSignupResendMagicLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}