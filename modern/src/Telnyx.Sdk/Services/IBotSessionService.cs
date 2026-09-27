using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotSessions;

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
public interface IBotSessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBotSessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Consumes the one-time portal redirect (magic link) token emailed during bot
/// signup and returns an API session. The token is a UUIDv7 that encodes its
/// creation time; it expires after a configurable validity window (15 minutes by
/// default) and is cleared on first use. Although the action creates a session, the
/// route uses the GET verb because it is opened from an email link. On first use
/// the account is also initialized. For bot signup (freemium) accounts the response
/// is a minimal envelope containing only the `api_v2_token`; accounts that are
/// permitted to use magic links but are not freemium accounts may instead receive
/// an extended session payload when additional steps (such as two-factor
/// authentication or identity verification) are required. This endpoint is public;
/// the magic link token in the query string is the credential.
/// </summary>
    Task<BotSessionListResponse> List(
        BotSessionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBotSessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBotSessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/bot_sessions</c>, but is otherwise the
/// same as <see cref="IBotSessionService.List(BotSessionListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BotSessionListResponse>> List(
        BotSessionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}