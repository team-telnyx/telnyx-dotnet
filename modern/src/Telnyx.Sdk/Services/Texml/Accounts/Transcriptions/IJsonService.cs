using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Transcriptions.Json;

namespace Telnyx.Sdk.Services.Texml.Accounts.Transcriptions;

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
/// Permanently deletes a recording transcription.
/// </summary>
    Task DeleteRecordingTranscriptionSidJson(
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingTranscriptionSidJson(JsonDeleteRecordingTranscriptionSidJsonParams, CancellationToken)"/>
    Task DeleteRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the recording transcription resource identified by its ID.
/// </summary>
    Task<TexmlRecordingTranscription> RetrieveRecordingTranscriptionSidJson(
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingTranscriptionSidJson(JsonRetrieveRecordingTranscriptionSidJsonParams, CancellationToken)"/>
    Task<TexmlRecordingTranscription> RetrieveRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
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
/// Returns a raw HTTP response for <c>delete /texml/Accounts/{account_sid}/Transcriptions/{recording_transcription_sid}.json</c>, but is otherwise the
/// same as <see cref="IJsonService.DeleteRecordingTranscriptionSidJson(JsonDeleteRecordingTranscriptionSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteRecordingTranscriptionSidJson(
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingTranscriptionSidJson(JsonDeleteRecordingTranscriptionSidJsonParams, CancellationToken)"/>
    Task<HttpResponse> DeleteRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Transcriptions/{recording_transcription_sid}.json</c>, but is otherwise the
/// same as <see cref="IJsonService.RetrieveRecordingTranscriptionSidJson(JsonRetrieveRecordingTranscriptionSidJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlRecordingTranscription>> RetrieveRecordingTranscriptionSidJson(
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingTranscriptionSidJson(JsonRetrieveRecordingTranscriptionSidJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlRecordingTranscription>> RetrieveRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}