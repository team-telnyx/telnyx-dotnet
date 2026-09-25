using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecordingsJsonService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecordingsJsonServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingsJsonService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Starts recording with specified parameters for call idientified by call_sid.
/// </summary>
    Task<TexmlCreateCallRecordingResponseBody> RecordingsJson(
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordingsJson(RecordingsJsonRecordingsJsonParams, CancellationToken)"/>
    Task<TexmlCreateCallRecordingResponseBody> RecordingsJson(
        string callSid,
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns recordings for a call identified by call_sid.
/// </summary>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(RecordingsJsonRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string callSid,
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRecordingsJsonService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecordingsJsonServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingsJsonServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Recordings.json</c>, but is otherwise the
/// same as <see cref="IRecordingsJsonService.RecordingsJson(RecordingsJsonRecordingsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingsJson(
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordingsJson(RecordingsJsonRecordingsJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingsJson(
        string callSid,
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Calls/{call_sid}/Recordings.json</c>, but is otherwise the
/// same as <see cref="IRecordingsJsonService.RetrieveRecordingsJson(RecordingsJsonRetrieveRecordingsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(RecordingsJsonRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        string callSid,
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}