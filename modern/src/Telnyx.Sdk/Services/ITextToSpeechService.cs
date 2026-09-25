using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TextToSpeech;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Text to speech streaming command operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITextToSpeechService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITextToSpeechServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITextToSpeechService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Generate synthesized speech audio from text input. Returns audio in the
/// requested format (binary audio stream, base64-encoded JSON, or an audio URL for
/// later retrieval).
/// 
/// <para>Authentication is provided via the standard `Authorization: Bearer
/// &lt;API_KEY&gt;` header.</para>
/// 
/// <para>The `voice` parameter provides a convenient shorthand to specify provider,
/// model, and voice in a single string (e.g. `Telnyx.Ultra.&lt;voice_id&gt;`).
/// Alternatively, specify `provider` explicitly along with provider-specific
/// parameters.</para>
/// 
/// <para>Supported providers: `aws`, `telnyx`, `azure`, `elevenlabs`, `minimax`,
/// `resemble`, `xai`, `humain`, `soniox`.</para>
/// 
/// <para>The Telnyx `Ultra` model supports 44 languages with emotion control, speed
/// adjustment, and volume control. Use the `telnyx` provider-specific parameters to
/// configure these features.</para>
/// </summary>
    Task<TextToSpeechGenerateSpeechResponse> GenerateSpeech(
        TextToSpeechGenerateSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of available voices from one or all TTS providers. When
/// `provider` is specified, returns voices for that provider only. Otherwise,
/// returns voices from all providers.
/// 
/// <para>Some providers (ElevenLabs, Resemble) require an API key to list voices.</para>
/// </summary>
    Task<TextToSpeechListVoicesResponse> ListVoices(
        TextToSpeechListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Open a WebSocket connection to stream text and receive synthesized audio in real
/// time. Authentication is provided via the standard `Authorization: Bearer
/// &lt;API_KEY&gt;` header. Send JSON frames with text to synthesize; receive JSON
/// frames containing base64-encoded audio chunks.
/// 
/// <para>Supported providers: `aws`, `telnyx`, `azure`, `minimax`, `resemble`,
/// `elevenlabs`, `xai`, `humain`, `soniox`.</para>
/// 
/// <para>**Connection flow:** 1. Open WebSocket with query parameters specifying
/// provider, voice, and model. 2. Send an initial handshake message `{"text": " "}`
/// (single space) with optional `voice_settings` to initialize the session. 3. Send
/// text messages as `{"text": "Hello world"}`. 4. Receive audio chunks as JSON
/// frames with base64-encoded audio. 5. A final frame with `isFinal: true`
/// indicates the end of audio for the current text.</para>
/// 
/// <para>To interrupt and restart synthesis mid-stream, send `{"force": true}` —
/// the current worker is stopped and a new one is started.</para>
/// 
/// <para>**Note:** The Telnyx `Ultra` model is not available over WebSocket. Use
/// the HTTP POST `/text-to-speech/speech` endpoint instead.</para>
/// </summary>
    Task RetrieveSpeech(
        TextToSpeechRetrieveSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITextToSpeechService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITextToSpeechServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITextToSpeechServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /text-to-speech/speech</c>, but is otherwise the
/// same as <see cref="ITextToSpeechService.GenerateSpeech(TextToSpeechGenerateSpeechParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TextToSpeechGenerateSpeechResponse>> GenerateSpeech(
        TextToSpeechGenerateSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /text-to-speech/voices</c>, but is otherwise the
/// same as <see cref="ITextToSpeechService.ListVoices(TextToSpeechListVoicesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TextToSpeechListVoicesResponse>> ListVoices(
        TextToSpeechListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /text-to-speech/speech</c>, but is otherwise the
/// same as <see cref="ITextToSpeechService.RetrieveSpeech(TextToSpeechRetrieveSpeechParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> RetrieveSpeech(
        TextToSpeechRetrieveSpeechParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}