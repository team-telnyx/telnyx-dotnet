using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotChallenge;

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
public interface IBotChallengeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBotChallengeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotChallengeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Generates a reverse-CAPTCHA challenge used to gate the bot signup flow. A random
/// active problem is selected from the pool; math problems are returned obfuscated
/// (case randomization, symbol injection, spacing noise) with an unobfuscated
/// rounding instruction appended, while string and binary problems are returned
/// as-is. The response contains a single-use nonce, the problem text, and the
/// current terms-and-conditions and privacy-policy URLs, which must be echoed back
/// on the signup request. Challenges expire after a short window (10 minutes by
/// default) and can only be answered once. This endpoint is public and
/// unauthenticated.
/// </summary>
    Task<BotChallengeCreateResponse> Create(
        BotChallengeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBotChallengeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBotChallengeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotChallengeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/bot_challenge</c>, but is otherwise the
/// same as <see cref="IBotChallengeService.Create(BotChallengeCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BotChallengeCreateResponse>> Create(
        BotChallengeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}