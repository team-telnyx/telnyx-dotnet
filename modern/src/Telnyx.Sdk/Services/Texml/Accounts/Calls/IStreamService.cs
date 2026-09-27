using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Streams;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStreamService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStreamServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Updates streaming resource for particular call.
/// </summary>
    Task<StreamStreamingSidJsonResponse> StreamingSidJson(
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StreamingSidJson(StreamStreamingSidJsonParams, CancellationToken)"/>
    Task<StreamStreamingSidJsonResponse> StreamingSidJson(
        string streamingSid,
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IStreamService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStreamServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Streams/{streaming_sid}.json</c>, but is otherwise the
/// same as <see cref="IStreamService.StreamingSidJson(StreamStreamingSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<StreamStreamingSidJsonResponse>> StreamingSidJson(
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StreamingSidJson(StreamStreamingSidJsonParams, CancellationToken)"/>
    Task<HttpResponse<StreamStreamingSidJsonResponse>> StreamingSidJson(
        string streamingSid,
        StreamStreamingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}