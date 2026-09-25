using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Siprec;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISiprecService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISiprecServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISiprecService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Updates siprec session identified by siprec_sid.
/// </summary>
    Task<SiprecSiprecSidJsonResponse> SiprecSidJson(
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SiprecSidJson(SiprecSiprecSidJsonParams, CancellationToken)"/>
    Task<SiprecSiprecSidJsonResponse> SiprecSidJson(
        string siprecSid,
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISiprecService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISiprecServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISiprecServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Siprec/{siprec_sid}.json</c>, but is otherwise the
/// same as <see cref="ISiprecService.SiprecSidJson(SiprecSiprecSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SiprecSiprecSidJsonResponse>> SiprecSidJson(
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SiprecSidJson(SiprecSiprecSidJsonParams, CancellationToken)"/>
    Task<HttpResponse<SiprecSiprecSidJsonResponse>> SiprecSidJson(
        string siprecSid,
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}