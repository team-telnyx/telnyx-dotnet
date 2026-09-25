using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailEvents;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Retrieve account-level email events and event statistics.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Lists account-level email events sorted oldest first by `occurred_at asc, id
/// asc`. Each row contains a legacy email.-prefixed event_type and an additive
/// canonical_event_type. Gateway rejection renders email.failed with canonical
/// email.gw_reject; ambiguous injection timeout renders email.injection_timeout in
/// both; MTA expiration renders email.bounced with canonical email.expired.
/// Message-scoped queued, sending, sandbox, cancelled, and daily_limit_exceeded
/// rows fan out per durable recipient with stable derived IDs matching webhook
/// delivery. Scheduled is the cardinality exception: account polling retains one
/// message-scoped scheduled row with its stored event ID, while scheduled webhook
/// publication fans out per recipient with derived IDs; reconcile scheduled events
/// by message ID, event type, and occurrence time rather than event UUID.
/// Recipient-scoped stored rows retain their stored UUIDs across polling and
/// webhook delivery. Legacy names are derived from stored rows; an AdminBounce row
/// stored as failed renders email.failed in polling while its webhook retains
/// email.bounced, both with canonical email.failed.
/// </summary>
    Task<EmailEventListPage> List(
        EmailEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns counts and rates for email events over a time range. The default start
/// time is 30 days ago.
/// </summary>
    Task<EmailEventRetrieveStatsResponse> RetrieveStats(
        EmailEventRetrieveStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_events</c>, but is otherwise the
/// same as <see cref="IEmailEventService.List(EmailEventListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailEventListPage>> List(
        EmailEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_events/stats</c>, but is otherwise the
/// same as <see cref="IEmailEventService.RetrieveStats(EmailEventRetrieveStatsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailEventRetrieveStatsResponse>> RetrieveStats(
        EmailEventRetrieveStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}