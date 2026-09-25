using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RecordingTranscriptions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Call Recordings operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecordingTranscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecordingTranscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingTranscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieves the details of an existing recording transcription.
/// </summary>
    Task<RecordingTranscriptionRetrieveResponse> Retrieve(
        RecordingTranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecordingTranscriptionRetrieveParams, CancellationToken)"/>
    Task<RecordingTranscriptionRetrieveResponse> Retrieve(
        string recordingTranscriptionID,
        RecordingTranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your recording transcriptions.
/// </summary>
    Task<RecordingTranscriptionListPage> List(
        RecordingTranscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a recording transcription.
/// </summary>
    Task<RecordingTranscriptionDeleteResponse> Delete(
        RecordingTranscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RecordingTranscriptionDeleteParams, CancellationToken)"/>
    Task<RecordingTranscriptionDeleteResponse> Delete(
        string recordingTranscriptionID,
        RecordingTranscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRecordingTranscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecordingTranscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingTranscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /recording_transcriptions/{recording_transcription_id}</c>, but is otherwise the
/// same as <see cref="IRecordingTranscriptionService.Retrieve(RecordingTranscriptionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingTranscriptionRetrieveResponse>> Retrieve(
        RecordingTranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecordingTranscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RecordingTranscriptionRetrieveResponse>> Retrieve(
        string recordingTranscriptionID,
        RecordingTranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /recording_transcriptions</c>, but is otherwise the
/// same as <see cref="IRecordingTranscriptionService.List(RecordingTranscriptionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingTranscriptionListPage>> List(
        RecordingTranscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /recording_transcriptions/{recording_transcription_id}</c>, but is otherwise the
/// same as <see cref="IRecordingTranscriptionService.Delete(RecordingTranscriptionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingTranscriptionDeleteResponse>> Delete(
        RecordingTranscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RecordingTranscriptionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<RecordingTranscriptionDeleteResponse>> Delete(
        string recordingTranscriptionID,
        RecordingTranscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}