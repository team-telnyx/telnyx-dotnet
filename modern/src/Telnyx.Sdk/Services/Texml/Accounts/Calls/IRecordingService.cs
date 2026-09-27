using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Recordings;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecordingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecordingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Updates recording resource for particular call.
/// </summary>
    Task<TexmlCreateCallRecordingResponseBody> RecordingSidJson(
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordingSidJson(RecordingRecordingSidJsonParams, CancellationToken)"/>
    Task<TexmlCreateCallRecordingResponseBody> RecordingSidJson(
        string recordingSid,
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRecordingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecordingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Recordings/{recording_sid}.json</c>, but is otherwise the
/// same as <see cref="IRecordingService.RecordingSidJson(RecordingRecordingSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingSidJson(
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordingSidJson(RecordingRecordingSidJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingSidJson(
        string recordingSid,
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}