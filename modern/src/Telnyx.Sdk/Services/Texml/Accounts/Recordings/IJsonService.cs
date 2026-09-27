using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts;
using Telnyx.Sdk.Models.Texml.Accounts.Recordings.Json;

namespace Telnyx.Sdk.Services.Texml.Accounts.Recordings;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IJsonService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJsonServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJsonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Deletes recording resource identified by recording id.
/// </summary>
    Task DeleteRecordingSidJson(
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingSidJson(JsonDeleteRecordingSidJsonParams, CancellationToken)"/>
    Task DeleteRecordingSidJson(
        string recordingSid,
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns recording resource identified by recording id.
/// </summary>
    Task<TexmlGetCallRecordingResponseBody> RetrieveRecordingSidJson(
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingSidJson(JsonRetrieveRecordingSidJsonParams, CancellationToken)"/>
    Task<TexmlGetCallRecordingResponseBody> RetrieveRecordingSidJson(
        string recordingSid,
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IJsonService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJsonServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJsonServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /texml/Accounts/{account_sid}/Recordings/{recording_sid}.json</c>, but is otherwise the
/// same as <see cref="IJsonService.DeleteRecordingSidJson(JsonDeleteRecordingSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteRecordingSidJson(
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingSidJson(JsonDeleteRecordingSidJsonParams, CancellationToken)"/>
    Task<HttpResponse> DeleteRecordingSidJson(
        string recordingSid,
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Recordings/{recording_sid}.json</c>, but is otherwise the
/// same as <see cref="IJsonService.RetrieveRecordingSidJson(JsonRetrieveRecordingSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlGetCallRecordingResponseBody>> RetrieveRecordingSidJson(
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingSidJson(JsonRetrieveRecordingSidJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlGetCallRecordingResponseBody>> RetrieveRecordingSidJson(
        string recordingSid,
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}