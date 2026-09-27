using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Audio;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudioService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAudioServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Transcribe speech to text. This endpoint is consistent with the [OpenAI
/// Transcription
/// API](https://platform.openai.com/docs/api-reference/audio/createTranscription)
/// and may be used with the OpenAI JS or Python SDK.
/// </summary>
    Task<AudioTranscribeResponse> Transcribe(
        AudioTranscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAudioService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudioServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/audio/transcriptions</c>, but is otherwise the
/// same as <see cref="IAudioService.Transcribe(AudioTranscribeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AudioTranscribeResponse>> Transcribe(
        AudioTranscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}