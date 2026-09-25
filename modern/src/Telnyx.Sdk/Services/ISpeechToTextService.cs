using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SpeechToText;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeechToTextService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeechToTextServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechToTextService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve the canonical list of supported speech-to-text providers, models,
/// accepted language codes, and the service types each model supports.
/// 
/// <para>Service types:   * `streaming` — standalone WebSocket transcription via
/// `/speech-to-text/transcription`.   * `file_based` — file-based transcription via
/// `/ai/audio/transcriptions`.   * `in_call` — live call transcription via Call
/// Control `transcription_start`.   * `ai_assistant` — STT configured on a Call
/// Control AI Assistant via voice-assistant `TranscriptionConfig` (covers both
/// live-streaming and non-streaming/batch models).</para>
/// 
/// <para>Use this endpoint to discover which (provider, model) combinations are
/// available for the surface you need, and which language codes each accepts.
/// `auto` in a `languages` array indicates the provider performs language
/// detection.</para>
/// </summary>
    Task<SpeechToTextListProvidersResponse> ListProviders(
        SpeechToTextListProvidersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Open a WebSocket connection to stream audio and receive transcriptions in
/// real-time. Authentication is provided via the standard `Authorization: Bearer
/// &lt;API_KEY&gt;` header.
/// 
/// <para>Supported engines: `Azure`, `Deepgram`, `Google`, `Telnyx`, `xAI`,
/// `Speechmatics`, `Soniox`, `Parakeet`, `Humain`, `Reson8`, `Cohere`.</para>
/// 
/// <para>**Connection flow:** 1. Open WebSocket with query parameters specifying
/// engine, input format, and language. 2. Send binary audio frames (mp3, wav,
/// linear16, or linear32 format, per `input_format`). 3. Receive JSON transcript
/// frames with `transcript`, `is_final`, and `confidence` fields. 4. Close
/// connection when done.</para>
/// </summary>
    Task RetrieveTranscription(
        SpeechToTextRetrieveTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISpeechToTextService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeechToTextServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechToTextServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /speech-to-text/providers</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.ListProviders(SpeechToTextListProvidersParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SpeechToTextListProvidersResponse>> ListProviders(
        SpeechToTextListProvidersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /speech-to-text/transcription</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.RetrieveTranscription(SpeechToTextRetrieveTranscriptionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> RetrieveTranscription(
        SpeechToTextRetrieveTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}